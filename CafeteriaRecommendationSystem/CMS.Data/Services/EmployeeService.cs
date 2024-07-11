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
        private IWeeklyMenuService _weeklyMenuService;
        private IFoodItemService _foodItemService;
        private IUserRepository _userRepository;
        private ISentimentAnalyzerService _sentimentAnalyzerService;
        public EmployeeService(IFeedbackService feedbackService,
            IWeeklyMenuService weeklyMenuService, IFoodItemService foodItemService,
            ISentimentAnalyzerService sentimentAnalyzerService,
            IUserRepository userRepository)
        {
            _feedbackService = feedbackService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
            _sentimentAnalyzerService = sentimentAnalyzerService;
            _userRepository = userRepository;
        }

        public async Task<string> SubmitFeedback(string submitFeedbackRequest)
        {
            Feedback feedback = JsonSerializer.Deserialize<Feedback>(submitFeedbackRequest);
            await ValidateFeedbackRequest(feedback);

            await _feedbackService.Add(feedback);

            await _sentimentAnalyzerService.UpdateSentimentAnalysis(feedback);

            return "Feedback submitted succesfully";
        }

        public async Task<string> ViewDailyMenu(DateTime date, int userId, Expression<Func<WeeklyMenu, bool>> predicate)
        {
            var foodItems = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem, FoodItem.FoodItemCharactersticMapping", null, null, 0, 0, predicate);

            ValidateMenu(date, foodItems);

            var menu = await GetDailyMenuByUserPreference(userId, foodItems);

            return JsonSerializer.Serialize(menu);
        }

        public async Task<string> SubmitUserCharactersticPreference(string userCharactersticPreferenceRequest)
        {
            var userCharactersticPreference = JsonSerializer.Deserialize<List<UserCharactersticPreference>>(userCharactersticPreferenceRequest);
            await _userRepository.SubmitUserPreferences(userCharactersticPreference);
            return "User characterstic preference has been recorded successfully";
        }

        public async Task<string> SubmitDetailedFeedback(string detailedFeedbackRequest)
        {
            var detailedFeeback = JsonSerializer.Deserialize<Common.Models.DetailedFeedback>(detailedFeedbackRequest);
            await ValidateDetailedFeedbackRequest(detailedFeeback);

            await _feedbackService.SubmitDetailedFeedback(detailedFeeback);

            return "Feedback submitted succesfully";
        }

        public async Task<string> VoteInFavourForMenuItem(string voteForFoodItemByMealTypeRequest)
        {
            var votedFoodItems = JsonSerializer.Deserialize<UserMealPreference>(voteForFoodItemByMealTypeRequest);

            await ValidateVotingRequestForUser(votedFoodItems);

            await VoteForMealItems(votedFoodItems.Breakfast);
            await VoteForMealItems(votedFoodItems.Lunch);
            await VoteForMealItems(votedFoodItems.Dinner);
            await _userRepository.SetVotingStatusForAUser(true, votedFoodItems.UserId);
            return "Voting has been submitted sucessfully!";
        }

        private async Task ValidateVotingRequestForUser(UserMealPreference dailyMenuRequest)
        {
            if (await IsMenuFinalised())
                throw new InvalidOperationException("Menu is already finalised, Voting has been closed!");

            if (await _userRepository.HasVotedToday(dailyMenuRequest.UserId))
                throw new InvalidOperationException("Voting for today has been submitted already");

            await ValidateItemsExistenceInPlannedMenuByMealType(dailyMenuRequest.Breakfast, 1);
            await ValidateItemsExistenceInPlannedMenuByMealType(dailyMenuRequest.Lunch, 2);
            await ValidateItemsExistenceInPlannedMenuByMealType(dailyMenuRequest.Dinner, 3);
        }

        private async Task<bool> IsMenuFinalised()
        {
            Expression<Func<WeeklyMenu, bool>> predicate = data =>
              data.CreatedDateTime.Date == DateTime.Today.Date && data.IsSelected;

            var finaledFoodItems = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

            if (finaledFoodItems.Count > 0) return true;
            return false;
        }

        private async Task ValidateItemsExistenceInPlannedMenuByMealType(List<string> foodItems, int mealTypeId)
        {
            var itemIds = foodItems.Select(int.Parse).ToList();

            Expression<Func<WeeklyMenu, bool>> predicate = data =>
                data.CreatedDateTime.Date == DateTime.Today.Date && itemIds.Contains(data.FoodItemId) && data.MealTypeId == mealTypeId;

            var plannedItemsForTomorrow = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 0, 0, predicate);

            var existingItemIds = plannedItemsForTomorrow.Select(m => m.FoodItemId).ToList();

            foreach (var item in itemIds)
            {
                if (!existingItemIds.Contains(item))
                {
                    throw new InvalidInputException($"Item with ID {item} does not exist in planned menu for tomorrow.");
                }
            }
        }

        private async Task VoteForMealItems(List<string> foodItems)
        {
            foreach (var item in foodItems)
            {
                int foodItemId = int.Parse(item);

                Expression<Func<WeeklyMenu, bool>> predicate = data =>
                    data.CreatedDateTime.Date == DateTime.Today && data.FoodItemId == foodItemId;

                var foodItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                    .FirstOrDefault();

                if (foodItem != null)
                {
                    foodItem.NumberOfVotes++;
                    await _weeklyMenuService.Update(foodItem.Id, foodItem);
                }
            }
        }

        private async Task ValidateFeedbackRequest(Feedback feedback)
        {
            var yesterday = DateTime.Today.AddDays(-1);

            Expression<Func<FoodItemFeedback, bool>> feedbackPredicate = f =>
                f.UserId == feedback.UserId &&
                f.FoodItemId == feedback.FoodItemId &&
                f.CreatedDateTime.Date == DateTime.Now.Date;

            var submittedFeedbacksByUser = await _feedbackService.GetList<FoodItemFeedback>(null, null, null, 0, 0, feedbackPredicate);

            if (submittedFeedbacksByUser.Any())
            {
                throw new InvalidOperationException("Feedback for this food item has already been submitted today");
            }

            Expression<Func<WeeklyMenu, bool>> weeklyMenuPredicate = w =>
           w.FoodItemId == feedback.FoodItemId &&
           w.CreatedDateTime.Date == yesterday.Date &&
           w.IsSelected;

            var todaysMenu = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 0, 0, weeklyMenuPredicate);
            if (!todaysMenu.Any())
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

        private void ValidateMenu(DateTime date, List<WeeklyMenu> weeklyMenuItems)
        {
            if (date.Date.Date == DateTime.Today.Date && weeklyMenuItems.Count == 0)
                throw new InvalidOperationException("Chef has not yet rolled out items for tomorrow menu");

            if (weeklyMenuItems.Count == 0)
                throw new InvalidOperationException("Menu is not finalised yet");

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

        private async Task<ViewMenu> GetDailyMenuByUserPreference(int userId, List<WeeklyMenu> foodItemsInMenu)
        {
            var user = await _userRepository.GetById(userId, "UserPreference");

            var groupedMenuItemsByMealType = foodItemsInMenu.GroupBy(u => u.MealTypeId).Select(group => new
            {
                MealTypeId = group.Key,
                FoodItems = group.OrderByDescending(item => CalculatePreferenceScore(item.FoodItem, user.UserPreference)).ToList()
            }); ;

            var menu = new ViewMenu();

            foreach (var group in groupedMenuItemsByMealType)
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
                        menu.Breakfast.AddRange(foodItems);
                        break;
                    case 2:
                        menu.Lunch.AddRange(foodItems);
                        break;
                    case 3:
                        menu.Dinner.AddRange(foodItems);
                        break;
                    default:
                        break;
                }
            }

            return menu;
        }
    }
}
