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
                        response = await employeeService.ViewNextDayMenu();
                        break;
                }
                return ProtocolResponseHelper.CreateSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
        }
    }
}
