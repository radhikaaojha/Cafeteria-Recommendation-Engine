﻿using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class CommonTaskExecutor : ITaskExecutor
    {
        private INotificationService _notificationService;
        private IFoodItemService _foodItemService;

        public CommonTaskExecutor(INotificationService notificationService, IFoodItemService foodItemService)
        {
            _notificationService = notificationService;
            _foodItemService = foodItemService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            try
            {
                string response = string.Empty;

                switch (action)
                {
                    case "ViewMenu":
                        response = await _foodItemService.ViewMenu();
                        break;
                    case "ViewNotifications":
                        response = await _notificationService.ViewNotifications(int.Parse(request));
                        break;
                    case "GenerateDiscardList":
                        response = await _foodItemService.GenerateDiscardedFoodItemList();
                        break;
                    case "RollOutDetailedFeedbackQuestions":
                        response = await _foodItemService.RollOutFeedbackQuestionnaireForDiscardedItem();
                        break;
                    case "DiscardFoodItem":
                        response = await _foodItemService.DiscardFoodItem(request);
                        break;
                    case "RemoveDiscardedFoodItem":
                        response = await _foodItemService.RemoveDiscardedFoodItem(request);
                        break;
                    case "Logout":
                        response = "Logging out user!";
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response, action);
            }
            catch (InvalidOperationException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (FoodItemNotFoundException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (Exception ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
        }

    }
}

