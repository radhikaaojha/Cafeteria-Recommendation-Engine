using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Repository.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManagementServer
{
    public class ClientRequestProcessor
    {
        private readonly TaskExecutorFactory _taskExecutorFactory;
        private IAppActivityLogRepository _appActivityLogRepository;
        private readonly ServerResponseHandler _serverResponseHandler;

        public ClientRequestProcessor(TaskExecutorFactory taskExecutorFactory, ServerResponseHandler serverResponseHandler, IAppActivityLogRepository appActivityLogRepository)
        {
            this._taskExecutorFactory = taskExecutorFactory;
            _appActivityLogRepository = appActivityLogRepository;
            this._serverResponseHandler = serverResponseHandler;
        }

        public async Task<string> ProcessClientRequest(CustomProtocolDTO request)
        {
            var requestJSON = request.Payload; 
            var requestedAction = request.Action;
            var userId = request.UserId;
            var response =  await PerformTheRequestedAction(userId,requestedAction, requestJSON);

            return _serverResponseHandler.CreateResponseForClient(response);
        }

        private async Task<string> PerformTheRequestedAction(string userId,string action, string jsonRequest)
        {
            var taskExecutor = _taskExecutorFactory.GetTaskExecutor(action);
            await _appActivityLogRepository.SaveActivityLogs(userId, action);
            return await taskExecutor.ExecuteTask(action,jsonRequest);
        }
    }
    
}
