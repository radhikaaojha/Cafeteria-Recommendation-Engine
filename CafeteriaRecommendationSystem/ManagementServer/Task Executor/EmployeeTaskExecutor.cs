using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class EmployeeTaskExecutor : ITaskExecutor
    {
        private IEmployeeService _employeeService;

        public EmployeeTaskExecutor(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            try
            {
                string response = string.Empty;
                Expression<Func<WeeklyMenu, bool>> predicate;
                switch (action)
                {
                    case "SubmitFeedback":
                        response = await _employeeService.SubmitFeedback(request);
                        break;
                    case "VoteForMenu":
                        response = await _employeeService.VoteInFavourForMenuItem((request));
                        break;
                    case "ViewRolledOutItems":
                        predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date;
                        response = await _employeeService.ViewDailyMenu(DateTime.Now, int.Parse(request),predicate);
                        break;
                    case "UserPreference":
                        response = await _employeeService.SubmitUserCharactersticPreference(request);
                        break;
                    case "SubmitDetailedFeedback":
                        response = await _employeeService.SubmitDetailedFeedback(request);
                        break;
                    case "ViewTodaysMenu":
                        DateTime yesterday = DateTime.Today.AddDays(-1);
                        predicate = data => data.CreatedDateTime.Date == yesterday.Date && data.IsSelected;
                        response = await _employeeService.ViewDailyMenu(yesterday, int.Parse(request), predicate);
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response, action);
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
