using CafeteriaRecommendationSystem.Services;
using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Services;
using CMS.Data.Services.Interfaces;
using Common;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ManagementServer
{
    public class Server
    {
        private const int PORT = 8000;
        private ClientRequestProcessor clientRequestProcessor;

        public Server(ClientRequestProcessor clientRequestProcessor)
        {
            this.clientRequestProcessor = clientRequestProcessor;
        }

        public async Task StartServer()
        {
            TcpListener server = null;
            try
            {
                
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(ipAddress, PORT);
                server.Start();
                Console.WriteLine($"Echo server started on {ipAddress}:{PORT}");
                while (true)
                {
                    Console.WriteLine("Waiting for a client connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected");

                    Task.Run(() => HandleClientRequest(client));
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }

        private async Task HandleClientRequest(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    while (true)
                    {
                        while (!reader.EndOfStream && !stream.DataAvailable)
                        {
                            await Task.Delay(10); // Wait for a short period before checking again
                        }

                        if (!stream.DataAvailable && stream.CanRead && stream.CanWrite)
                        {
                            // Client disconnected
                            Console.WriteLine("Client disconnected.");
                            break;
                        }

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
                        var response = await clientRequestProcessor.ProcessClientRequest(request);

                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        //BASE 64 RESPONSE -and size of response client validates 
                        await writer.WriteLineAsync(responseBytes.Length.ToString());
                        await writer.WriteLineAsync(response);
                        await writer.FlushAsync();
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
    }
}