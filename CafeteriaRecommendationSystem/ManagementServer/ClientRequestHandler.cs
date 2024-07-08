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
    public class ClientRequestHandler
    {
        private readonly TaskExecutorFactory _taskExecutorFactory;
        private IAppActivityLogRepository _appActivityLogRepository;

        public ClientRequestHandler(TaskExecutorFactory taskExecutorFactory,IAppActivityLogRepository appActivityLogRepository)
        {
            this._taskExecutorFactory = taskExecutorFactory;
            _appActivityLogRepository = appActivityLogRepository;
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

        public async Task<string> ProcessClientRequest(CustomProtocol request)
        {
            var requestJSON = request.Payload;
            var requestedAction = request.Action;
            var userId = request.UserId;
            var response = await PerformTheRequestedAction(userId, requestedAction, requestJSON);

            return CreateResponseForClient(response);
        }

        private async Task<string> PerformTheRequestedAction(string userId,string action, string jsonRequest)
        {
            var taskExecutor = _taskExecutorFactory.GetTaskExecutor(action);
            await _appActivityLogRepository.SaveActivityLogs(userId, action);
            return await taskExecutor.ExecuteTask(action,jsonRequest);
        }

        private CustomProtocol DeserializeRequest(string message)
        {
            return JsonSerializer.Deserialize<CustomProtocol>(message);
        }

        public string CreateResponseForClient(string responseData)
        {
            var customProtocolResponse = JsonSerializer.Deserialize<CustomProtocol>(responseData);
            return SerializeResponse(customProtocolResponse);
        }

        private string SerializeResponse(CustomProtocol response)
        {
            return JsonSerializer.Serialize(response);
        }
    }
    
}
