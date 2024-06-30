using CMS.Common.Models;
using CMS.Common.Utils;
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
        private readonly TaskExecutorFactory taskExecutorFactory;
        private readonly ServerResponseHandler serverResponseHandler;

        public ClientRequestProcessor(TaskExecutorFactory taskExecutorFactory, ServerResponseHandler serverResponseHandler)
        {
            this.taskExecutorFactory = taskExecutorFactory;
            this.serverResponseHandler = serverResponseHandler;
        }

        public async Task<string> ProcessClientRequest(CustomProtocolDTO request)
        {
            var requestJSON = request.Payload; 
            var requestedAction = request.Action;

            var response =  await PerformTheRequestedAction(requestedAction, requestJSON);

            return serverResponseHandler.CreateResponseForClient(response);
        }

        private async Task<string> PerformTheRequestedAction(string action, string jsonRequest)
        {
            var taskExecutor = taskExecutorFactory.GetTaskExecutor(action);
            return await taskExecutor.ExecuteTask(action,jsonRequest);
        }
    }
    
}
