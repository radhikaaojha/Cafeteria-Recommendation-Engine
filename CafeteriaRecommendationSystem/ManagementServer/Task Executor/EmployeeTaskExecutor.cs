using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class EmployeeTaskExecutor : ITaskExecutor
    {
        private IEmployeeService employeeService;

        public EmployeeTaskExecutor(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            try
            {
                string response = string.Empty;

                switch (action)
                {
                    case "SubmitFeedback":
                        response = await employeeService.GiveFeedback(request);
                        break;
                    case "VoteForMenu":
                        response = await employeeService.VoteInFavourForMenuItem((request));
                        break;
                    case "ViewNextDayMenu":
                        response = await employeeService.ViewDailyMenu(DateTime.Now, int.Parse(request));
                        break;
                    case "UserPreference":
                        response = await employeeService.SubmitUserPreference(request);
                        break;
                    case "SubmitDetailedFeedback":
                        response = await employeeService.SubmitDetailedFeedback(request);
                        break;
                    case "ViewTodaysMenu":
                        DateTime yesterday = DateTime.Today.AddDays(-1);
                        response = await employeeService.ViewDailyMenu(yesterday, int.Parse(request));
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response);
            }
            catch (FoodItemNotFoundException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
            catch (InvalidOperationException ex)
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
