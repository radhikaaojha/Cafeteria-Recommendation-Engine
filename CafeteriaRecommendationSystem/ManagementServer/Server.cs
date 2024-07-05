using CMS.Common.Models;
using Common;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ManagementServer
{
    public class Server
    {
        private static readonly ConcurrentDictionary<string, TcpClient> _connectedClients = new ConcurrentDictionary<string, TcpClient>();
        private ClientRequestProcessor _clientRequestProcessor;

        public Server(ClientRequestProcessor clientRequestProcessor)
        {
            this._clientRequestProcessor = clientRequestProcessor;
        }

        public async Task StartServer()
        {
            TcpListener server = null;
            try
            {
                IPAddress ipAddress = IPAddress.Parse(AppConstants.SERVER_IP);
                server = new TcpListener(ipAddress, AppConstants.PORT);
                server.Start();
                Console.WriteLine($"Server started on {ipAddress}:{AppConstants.PORT}");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    _connectedClients.TryAdd(client.Client.RemoteEndPoint.ToString(), client);
                    Console.WriteLine($"Client {client.Client.RemoteEndPoint.ToString()} connected");
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
                            var response = await _clientRequestProcessor.ProcessClientRequest(request);

                            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                            await writer.WriteLineAsync(responseBytes.Length.ToString());
                            await writer.WriteLineAsync(response);
                            await writer.FlushAsync();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine($"Client {client.Client.RemoteEndPoint} disconnected: {e.Message}");
                            _connectedClients.TryRemove(client.Client.RemoteEndPoint.ToString(), out _);
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
    }
}