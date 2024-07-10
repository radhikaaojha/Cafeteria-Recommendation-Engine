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
        private IChefService _chefService;

        public ChefTaskExecutor(IChefService chefService)
        {
            this._chefService = chefService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            try
            {
                string response = string.Empty;

                switch (action)
                {
                    case "PlanNextDayMenu":
                        response = await _chefService.PlanMenuForNextDay(request);
                        break;
                    case "FinalizeMenu":
                        response = await _chefService.FinalizeMenuItems(request);
                        break;
                    case "ViewVotes":
                        response = await _chefService.GetEmployeeVotes();
                        break;
                    case "TopRecommendations":
                        response = await _chefService.GetTopRecommendations();
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response, action);
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
