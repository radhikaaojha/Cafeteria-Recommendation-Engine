using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Repository.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public async Task HandleClientRequest(TcpClient client)
        {
            StreamWriter writer = null;
            try
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    while (true)
                    {
                        try
                        {
                            string lengthString = await reader.ReadLineAsync();
                            if (string.IsNullOrWhiteSpace(lengthString))
                            {
                                continue;
                            }
                            int dataLength = int.Parse(lengthString);
                            char[] dataBuffer = new char[dataLength];
                            await reader.ReadBlockAsync(dataBuffer, 0, dataLength);
                            string requestString = new string(dataBuffer);

                            var request = DeserializeRequest(requestString);
                            var response = await ProcessClientRequest(request);

                            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                            await writer.WriteLineAsync(responseBytes.Length.ToString());
                            await writer.WriteLineAsync(response);
                            await writer.FlushAsync();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine($"Client {client.Client.RemoteEndPoint} disconnected: {e.Message}");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Client {client.Client.RemoteEndPoint} disconnected: {e.Message}");
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
        }

        private CustomProtocolDTO DeserializeRequest(string message)
        {
            return JsonSerializer.Deserialize<CustomProtocolDTO>(message);
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
