using CMS.Common.Exceptions;
using CMS.Common.Models;
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
            FeedbackRequest feedbackRequest = JsonSerializer.Deserialize<FeedbackRequest>(request);
            await ValidateFeedbackRequest(feedbackRequest);

            await _feedbackService.Add(feedbackRequest);

            await UpdateSentimentAnalysis(feedbackRequest);
           
            return "Feedback submitted succesfully";
        }

        public async Task<string> ViewDailyMenu(DateTime date)
        {
            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == date.Date && data.IsSelected;
            var weeklyMenuItems = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem", null, null, 0, 0, predicate);
            
            if (weeklyMenuItems.Count == 0)
                return "Menu has not yet been finalised";

            var groupedItems = weeklyMenuItems.GroupBy(u => u.MealTypeId);

            var viewNextDayMenu = new ViewNextDayMenu();

            foreach (var group in groupedItems)
            {
                var foodItems = group.Select(u => new RecommendedItem
                {
                    Id = u.FoodItem.Id,
                    Name = u.FoodItem.Name,
                    Description = u.FoodItem.Description,
                    SentimentScore = u.FoodItem.SentimentScore
                }).ToList();

                switch (group.Key)
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

        public async Task<string> SubmitDetailedFeedback(string request)
        {
            var feedbackRequest = JsonSerializer.Deserialize<DetailedFeedbackRequest>(request);
            await ValidateDetailedFeedbackRequest(feedbackRequest);

            await _feedbackService.SubmitDetailedFeedback(feedbackRequest);

            return "Feedback submitted succesfully";
        }

        public async Task<string> VoteInFavourForMenuItem(string request)
        {
            var votingMenuRequest = JsonSerializer.Deserialize<VotingMenuInput>(request);

            await ValidateVotingItems(votingMenuRequest);

            await VoteForMealItems(votingMenuRequest.Breakfast,votingMenuRequest.UserId);
            await VoteForMealItems(votingMenuRequest.Lunch, votingMenuRequest.UserId);
            await VoteForMealItems(votingMenuRequest.Dinner, votingMenuRequest.UserId);
            
            return "Voting has been submitted sucessfully!";
        }

        private async Task ValidateVotingItems(DailyMenuInput dailyMenuRequest)
        {
            await ValidateItemsExistInWeeklyMenu(dailyMenuRequest.Breakfast);
            await ValidateItemsExistInWeeklyMenu(dailyMenuRequest.Lunch);
            await ValidateItemsExistInWeeklyMenu(dailyMenuRequest.Dinner);
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
                    throw new InvalidInputException($"Item with ID {item} does not exist in today's menu.");
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
                    var user = await _userRepository.GetById(userId);
                    user.HasVotedToday = true;
                    await _userRepository.Update(user);
                }
                else
                {
                    throw new InvalidOperationException("User has already voted for the day!");
                }
            }
        }

        private async Task ValidateFeedbackRequest(FeedbackRequest request)
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

        private async Task ValidateDetailedFeedbackRequest(DetailedFeedbackRequest request)
        {
            var foodItem = await _foodItemService.GetById<FoodItem>(request.FoodItemId);
            if (foodItem == null)
                throw new FoodItemNotFoundException("Food item with given id doesnt exist");
            if (foodItem.StatusId != (int)Status.Discarded)
                throw new InvalidOperationException("Food item isn't in the discarded list so cannot submit detailed feedback");
        }

        private async Task UpdateSentimentAnalysis(FeedbackRequest feedbackRequest)
        {
            var (rating, feedbacks) = await _feedbackService.AnalyzeFeedbackSentiments(feedbackRequest.FoodItemId);
            await _foodItemService.UpdateSentimentResult(rating, feedbacks, feedbackRequest.FoodItemId);

            if (rating < 20 && ContainsNegativeKeywords(feedbacks))
            {
                await _foodItemService.AddToDiscardList(feedbackRequest.FoodItemId);
            }

        }
        private bool ContainsNegativeKeywords(string feedback)
        {
            var negativeKeywords = new List<string> { "Tasteless", "extremely bad experience", "very poor", "bad", "disgusting","not good","gross","poor" };

            foreach (var keyword in negativeKeywords)
            {
                if (feedback.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
