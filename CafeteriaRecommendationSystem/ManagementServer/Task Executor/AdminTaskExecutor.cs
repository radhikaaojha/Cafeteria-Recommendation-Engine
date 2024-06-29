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
        private IAdminService adminService;

        public AdminTaskExecutor(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            string response = string.Empty;
            try
            {
                switch (action)
                {
                    case "AddFoodItem":
                        response = await adminService.AddFoodItem(request);
                        break;
                    case "RemoveFoodItem":
                        response = await adminService.RemoveFoodItem(request);
                        break;
                    case "UpdateFoodItemPrice":
                        response = await adminService.UpdatePriceForFoodItem(request);
                        break;
                    case "UpdateFoodItemStatus":
                        response = await adminService.UpdateAvailabilityStatusForFoodItem(request);
                        break;
                }
                return CreateSuccessResponse(response);
            }
            catch(FoodItemExistsException ex)
            {
                return CreateFailureResponse(ex.Message);
            }
            
        }

        private string CreateSuccessResponse(string response)
        {
            var successResponse = new CustomProtocolDTO
            {
                Response = response,
                Action = "Sucess"
            };

            return JsonSerializer.Serialize(successResponse);
        }

        private string CreateFailureResponse(string response)
        {
            var successResponse = new CustomProtocolDTO
            {
                Response = response,
                Action = "Exception"
            };

            return JsonSerializer.Serialize(successResponse);
        }
    }
}
