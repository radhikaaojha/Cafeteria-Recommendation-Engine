using CMS.Common.Exceptions;
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
    public class AdminTaskExecutor : ITaskExecutor
    {
        private IAdminService _adminService;

        public AdminTaskExecutor(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            string response = string.Empty;
            try
            {
                switch (action)
                {
                    case "AddFoodItem":
                        response = await _adminService.AddFoodItem(request);
                        break;
                    case "RemoveFoodItem":
                        response = await _adminService.RemoveFoodItem(request);
                        break;
                    case "UpdateFoodItemPrice":
                        response = await _adminService.UpdatePriceForFoodItem(request);
                        break;
                    case "UpdateFoodItemStatus":
                        response = await _adminService.UpdateAvailabilityStatusForFoodItem(request);
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response);
            }
            catch(ApiException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (FoodItemExistsException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (FoodItemNotFoundException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            } 
            catch (ArgumentOutOfRangeException ex)
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
