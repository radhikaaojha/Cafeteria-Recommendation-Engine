using CMS.Common.Enums;
using CMS.Common.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Client
{
    public class Client
    {
        private const string SERVER_IP = "127.0.0.1";
        private const int PORT = 8000;

        public static async Task Main(string[] args)
        {
            string choice = "Y";
            TcpClient client = new();
            try
            {
                await client.ConnectAsync(SERVER_IP, PORT);
                Console.WriteLine("Connected to the server.");
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var response = await Authenticate(writer, reader);
                    do
                    {
                        switch (response)
                        {
                            case "1":
                                var request = await AdminService.ShowMenuForAdmin(writer, reader);
                                await SendRequestAsync(writer, reader, request);
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                        }
                        Console.WriteLine("Do you wish to continue: Choose Y/N");
                        choice = Console.ReadLine()?.Trim().ToUpper();
                    }
                    while (choice == "Y");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            finally
            {
                client.Close();
            }
        }

        private static async Task<string> Authenticate(StreamWriter writer, StreamReader reader)
        {
            Console.WriteLine("Enter employeeId");
            var employeeId = Console.ReadLine();
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();

            CustomProtocolDTO authRequest = new CustomProtocolDTO
            {
                Action = Actions.Auth.ToString(),
                Payload = JsonSerializer.Serialize(new { EmployeeId = employeeId, Name = name })
            };

            return await SendRequestAsync(writer, reader, authRequest);
        }

        private static async Task<string> SendRequestAsync(StreamWriter writer, StreamReader reader, CustomProtocolDTO request)
        {
            {
                string requestString = JsonSerializer.Serialize(request);
                await writer.WriteLineAsync(requestString.Length.ToString());
                await writer.WriteLineAsync(requestString);
                return await HandleServerResponse(reader);
            }
        }

        private static async Task<string> HandleServerResponse(StreamReader reader)
        {
            while (true)
            {
                string lengthString = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(lengthString))
                {
                    break;
                }

                if (!int.TryParse(lengthString, out int dataLength))
                {
                    Console.WriteLine("Invalid data length received from server.");
                    continue;
                }

                char[] buffer = new char[dataLength];
                int bytesRead = await reader.ReadAsync(buffer, 0, dataLength);
                if (bytesRead != dataLength)
                {
                    Console.WriteLine("Unexpected data length received from server.");
                    continue;
                }

                string responseData = new string(buffer);
                try
                {
                    CustomProtocolDTO response = JsonSerializer.Deserialize<CustomProtocolDTO>(responseData);
                    Console.WriteLine($"Response: {response.Response}");
                    return response.Response;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                    return ex.Message;
                }

            }
            return "";
        }
    }
}