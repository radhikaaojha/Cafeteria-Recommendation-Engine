using CMS.Common.Enums;
using CMS.Common.Models;
using Common.Models;
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
            TcpClient client = new();
            try
            {
                await client.ConnectAsync(SERVER_IP, PORT);
                Console.WriteLine("Connected to the server.");
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var response = JsonSerializer.Deserialize<LoginResponse>(await Authenticate(writer, reader));
                    Console.WriteLine($"{response.Message}");
                    bool exitRequested = false;
                    while (!exitRequested)
                    {
                        CustomProtocolDTO request = new();
                        switch (response.RoleId.ToString())
                        {
                            case "1":
                                request = await AdminService.ShowMenuForAdmin(writer, reader);
                                break;
                            case "2":
                                request = await ChefService.ShowMenuForChef(writer, reader, response.UserId);
                                break;
                            case "3":
                                request = await EmployeeService.ShowMenuForEmployee(writer, reader, response.UserId);
                                break;
                        }

                        if (request.Action == "Logout")
                        {
                            exitRequested = true;
                            continue;
                        }

                        var result = await SendRequestAsync(writer, reader, request);
                        FormatJson(result);
                    }
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
        public static void FormatJson(string json)
        {
            bool inQuotes = false;
            int indentLevel = 0;
            string currentLine = "";

            foreach (char c in json)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }

                if (!inQuotes && (c == ',' || c == '{' || c == '}'))
                {
                    if (c == '{')
                    {
                        indentLevel++;
                    }

                    currentLine += c;
                    currentLine += Environment.NewLine;

                    if (c == '}')
                    {
                        indentLevel--;
                        currentLine += new string(' ', indentLevel * 4); // Adjust indentation
                    }
                }
                else
                {
                    currentLine += c;
                }
            }

            Console.WriteLine(currentLine);
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
            string requestString = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                MaxDepth = 128
            });
            await writer.WriteLineAsync(requestString.Length.ToString());
            await writer.WriteLineAsync(requestString);
            return await HandleServerResponse(reader);
        }

        private static async Task<string> HandleServerResponse(StreamReader reader)
        {
            CustomProtocolDTO response = new();
            while (true)
            {
                string lengthString = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(lengthString))
                {
                    continue;
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
                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                        MaxDepth = 128
                    };
                    response = JsonSerializer.Deserialize<CustomProtocolDTO>(responseData);
                    return response.Response;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                    return ex.Message;
                }

            }
        }
    }
}