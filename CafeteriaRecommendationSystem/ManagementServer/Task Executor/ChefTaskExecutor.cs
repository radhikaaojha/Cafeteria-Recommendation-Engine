using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Common.Utils
{
    public class ChefTaskExecutor : ITaskExecutor
    {
        private IChefService chefService;

        public ChefTaskExecutor(IChefService chefService)
        {
            this.chefService = chefService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            try
            {
                string response = string.Empty;

                switch (action)
                {
                    case "PlanNextDayMenu":
                        response = await chefService.PlanDailyMenu(request);
                        break;
                    case "FinalizeMenu":
                        response = await chefService.FinalizeMenuItems(request);
                        break;
                    case "ViewVotes":
                        response = await chefService.GetEmployeeVotes();
                        break;
                    case "TopRecommendations":
                        response = await chefService.GetTopRecommendations();
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response);
            }
            catch (FoodItemNotFoundException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (ApiException ex)
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
