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

            var actionResponse = await PerformTheRequestedAction(requestedAction, requestJSON);

            return serverResponseHandler.CreateResponseForClient(actionResponse.Response, actionResponse.ErrorMessage);
        }

        private async Task<ActionResponseDTO> PerformTheRequestedAction(string action, string jsonRequest)
        {
            var taskExecutor = taskExecutorFactory.GetTaskExecutor(action);
            var jsonResponse = await taskExecutor.ExecuteTask(action,jsonRequest);
            return ConstructActionResponseObject(true, jsonResponse, "");
        }

        private ActionResponseDTO ConstructActionResponseObject(bool success, string response, string errorMessage)
        {
            return new ActionResponseDTO
            {
                Success = success,
                Response = response,
                ErrorMessage = errorMessage
            };
        }
        private CustomProtocolDTO DeserializeRequest(string message)
        {
            return JsonSerializer.Deserialize<CustomProtocolDTO>(message);
        }
    }
    public class ActionResponseDTO
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public string ErrorMessage { get; set; }
    }
}
