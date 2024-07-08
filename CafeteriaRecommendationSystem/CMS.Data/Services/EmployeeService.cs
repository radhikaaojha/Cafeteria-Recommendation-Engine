using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Entities;
using CMS.Data.Services.Interfaces;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.Linq.Expressions;
using System.Text.Json;

namespace CMS.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFeedbackService _feedbackService;
        private INotificationService _notificationService;
        private IWeeklyMenuService _weeklyMenuService;
        private IFoodItemService _foodItemService;
        private IUserRepository _userRepository;
        public EmployeeService(IFeedbackService feedbackService, INotificationService notificationService,
            IWeeklyMenuService weeklyMenuService, IFoodItemService foodItemService,
            IUserRepository userRepository)
        {
            _feedbackService = feedbackService;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
            _userRepository = userRepository;
        }

        public async Task<string> GiveFeedback(string request)
        {
            Feedback feedbackRequest = JsonSerializer.Deserialize<Feedback>(request);
            await ValidateFeedbackRequest(feedbackRequest);

            await _feedbackService.Add(feedbackRequest);

            await UpdateSentimentAnalysis(feedbackRequest);

            return "Feedback submitted succesfully";
        }

        public async Task<string> ViewDailyMenu(DateTime date, int userId, Expression<Func<WeeklyMenu, bool>> predicate)
        {
            var weeklyMenuItems = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem, FoodItem.FoodItemCharactersticMapping", null, null, 0, 0, predicate);

            if (date.Date.Date == DateTime.Today.Date && weeklyMenuItems.Count == 0)
                throw new InvalidOperationException("Chef has not yet rolled out items for tomorrow menu");

            if (weeklyMenuItems.Count == 0)
                throw new InvalidOperationException("Menu is not finalised yet");

            var user = await _userRepository.GetById(userId, "UserPreference");

            var groupedItems = weeklyMenuItems.GroupBy(u => u.MealTypeId).Select(group => new
            {
                MealTypeId = group.Key,
                FoodItems = group.OrderByDescending(item => CalculatePreferenceScore(item.FoodItem, user.UserPreference)).ToList()
            }); ;

            var viewNextDayMenu = new BrowseNextDayMenu();

            foreach (var group in groupedItems)
            {
                var foodItems = group.FoodItems.Select(u => new RecommendedItem
                {
                    Id = u.FoodItem.Id,
                    Name = u.FoodItem.Name,
                    Description = u.FoodItem.Description,
                    SentimentScore = u.FoodItem.SentimentScore
                }).ToList();

                switch (group.MealTypeId)
                {
                    case 1:
                        viewNextDayMenu.Breakfast.AddRange(foodItems);
                        break;
                    case 2:
                        viewNextDayMenu.Lunch.AddRange(foodItems);
                        break;
                    case 3:
                        viewNextDayMenu.Dinner.AddRange(foodItems);
                        break;
                    default:
                        break;
                }
            }

            return JsonSerializer.Serialize(viewNextDayMenu);
        }

        private int CalculatePreferenceScore(FoodItem foodItem, List<UserPreference> userPreferences)
        {
            int score = 0;
            foreach (var characteristic in foodItem.FoodItemCharactersticMapping)
            {
                var preference = userPreferences.FirstOrDefault(p => p.CharacteristicId == characteristic.CharacteristicId);
                if (preference != null)
                {
                    score += (userPreferences.Count - preference.Priority + 1);
                }
            }
            return score;
        }

        public async Task<string> SubmitUserPreference(string request)
        {
            var userPreference = JsonSerializer.Deserialize<List<UserPreferences>>(request);
            await _userRepository.SubmitUserPreferences(userPreference);
            return "User preference has been recorded successfully";
        }

        public async Task<string> SubmitDetailedFeedback(string request)
        {
            var feedbackRequest = JsonSerializer.Deserialize<Common.Models.DetailedFeedback>(request);
            await ValidateDetailedFeedbackRequest(feedbackRequest);

            await _feedbackService.SubmitDetailedFeedback(feedbackRequest);

            return "Feedback submitted succesfully";
        }

        public async Task<string> VoteInFavourForMenuItem(string request)
        {
            var votingMenuRequest = JsonSerializer.Deserialize<UserMealPreference>(request);

            await ValidateVotingOfUser(votingMenuRequest);

            await VoteForMealItems(votingMenuRequest.Breakfast, votingMenuRequest.UserId);
            await VoteForMealItems(votingMenuRequest.Lunch, votingMenuRequest.UserId);
            await VoteForMealItems(votingMenuRequest.Dinner, votingMenuRequest.UserId);
            await _userRepository.SetVotingStatusForAUser(true, votingMenuRequest.UserId);
            return "Voting has been submitted sucessfully!";
        }

        private async Task ValidateVotingOfUser(UserMealPreference dailyMenuRequest)
        {
            if (await IsMenuFinalised())
                throw new InvalidOperationException("Menu is already finalised, Voting has been closed!");

            if (await _userRepository.HasVotedToday(dailyMenuRequest.UserId))
                throw new InvalidOperationException("Voting for today has been submitted already");

            await ValidateItemsExistInWeeklyMenu(dailyMenuRequest.Breakfast);
            await ValidateItemsExistInWeeklyMenu(dailyMenuRequest.Lunch);
            await ValidateItemsExistInWeeklyMenu(dailyMenuRequest.Dinner);
        }

        private async Task<bool> IsMenuFinalised()
        {
            Expression<Func<WeeklyMenu, bool>> predicate = data =>
              data.CreatedDateTime.Date == DateTime.Today.Date && data.IsSelected;

            var menuItems = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

            if (menuItems.Count > 0) return true;
            return false;
        }

        private async Task ValidateItemsExistInWeeklyMenu(List<string> items)
        {
            var itemIds = items.Select(int.Parse).ToList();

            Expression<Func<WeeklyMenu, bool>> predicate = data =>
                data.CreatedDateTime.Date == DateTime.Today.Date && itemIds.Contains(data.FoodItemId);

            var menuItems = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 0, 0, predicate);

            var existingItemIds = menuItems.Select(m => m.FoodItemId).ToList();

            foreach (var item in itemIds)
            {
                if (!existingItemIds.Contains(item))
                {
                    throw new InvalidInputException($"Item with ID {item} does not exist in todays menu.");
                }
            }
        }

        private async Task VoteForMealItems(List<string> items, int userId)
        {
            foreach (var item in items)
            {
                int foodItemId = int.Parse(item);

                if (!await _userRepository.HasVotedToday(userId))
                {
                    Expression<Func<WeeklyMenu, bool>> predicate = data =>
                        data.CreatedDateTime.Date == DateTime.Today && data.FoodItemId == foodItemId;

                    var menuItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();

                    if (menuItem != null)
                    {
                        menuItem.NumberOfVotes++;
                        await _weeklyMenuService.Update(menuItem.Id, menuItem);
                    }
                }
                else
                {
                    throw new InvalidOperationException("User has already voted for the day!");
                }
            }
        }

        private async Task ValidateFeedbackRequest(Feedback request)
        {
            var yesterday = DateTime.Today.AddDays(-1);

            Expression<Func<FoodItemFeedback, bool>> feedbackPredicate = f =>
                f.UserId == request.UserId &&
                f.FoodItemId == request.FoodItemId &&
                f.CreatedDateTime.Date == DateTime.Now.Date;

            var feedbackList = await _feedbackService.GetList<FoodItemFeedback>(null, null, null, 0, 0, feedbackPredicate);

            if (feedbackList.Any())
            {
                throw new InvalidOperationException("Feedback for this food item has already been submitted today");
            }

            Expression<Func<WeeklyMenu, bool>> weeklyMenuPredicate = w =>
           w.FoodItemId == request.FoodItemId &&
           w.CreatedDateTime.Date == yesterday.Date &&
           w.IsSelected;

            var weeklyMenuList = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 0, 0, weeklyMenuPredicate);
            if (!weeklyMenuList.Any())
            {
                throw new InvalidOperationException("The food item is not part of the selected menu for today.");
            }
        }

        private async Task ValidateDetailedFeedbackRequest(Common.Models.DetailedFeedback request)
        {
            var foodItem = await _foodItemService.GetById<FoodItem>(request.FoodItemId);
            if (foodItem == null)
                throw new FoodItemNotFoundException("Food item with given id doesnt exist");
            if (foodItem.StatusId != (int)Status.Discarded)
                throw new InvalidOperationException("Food item is not in the discarded list so cannot submit detailed feedback");
        }

        private async Task UpdateSentimentAnalysis(Feedback feedbackRequest)
        {
            var (rating, feedbacks) = await _feedbackService.AnalyzeFeedbackSentiments(feedbackRequest.FoodItemId);
            await _foodItemService.UpdateSentimentResult(rating, feedbacks, feedbackRequest.FoodItemId);
        }
    }
}
