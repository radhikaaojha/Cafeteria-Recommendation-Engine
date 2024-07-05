using CMS.Common.Enums;
using CMS.Common.Models;
using Common;
using Common.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Client
{
    public class Client
    {

        public static async Task Main(string[] args)
        {
            TcpClient client = new();
            try
            {
                await client.ConnectAsync(AppConstants.SERVER_IP, AppConstants.PORT);
                Console.WriteLine("Connected to the server.");
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var response = (await Authenticate(writer, reader));
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(response.Response);
                    Console.WriteLine($"{loginResponse.Message}");
                    await ProcessUserRequests(loginResponse, writer, reader, client);
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

        private static async Task ProcessUserRequests(LoginResponse response, StreamWriter writer, StreamReader reader, TcpClient client)
        {
            bool exitRequested = false;
            while (!exitRequested)
            {
                CustomProtocolDTO request = await GetRequestForUserRole(response);
                if (request.Action == Actions.Logout.ToString())
                {
                    exitRequested = true;
                    continue;
                }

                var result = await SendRequestAsync(writer, reader, request);
                await HandleAction(result);
            }
        }

        private static async Task<CustomProtocolDTO> GetRequestForUserRole(LoginResponse response)
        {
            if (response.UserId == 0)
            {
                Environment.Exit(0);
            }

            return response.RoleId switch
            {
                1 => await AdminService.ShowMenuForAdmin(response.UserId),
                2 => await ChefService.ShowMenuForChef(response.UserId),
                3 => await EmployeeService.ShowMenuForEmployee(response.UserId),
                _ => throw new InvalidOperationException("Invalid RoleId")
            };
        }

        private static async Task<CustomProtocolDTO> Authenticate(StreamWriter writer, StreamReader reader)
        {
            var (employeeId, name) = GetInputForLogin();

            CustomProtocolDTO authRequest = new CustomProtocolDTO
            {
                UserId = employeeId,
                Action = Actions.Auth.ToString(),
                Payload = JsonSerializer.Serialize(new { EmployeeId = employeeId, Name = name })
            };

            return await SendRequestAsync(writer, reader, authRequest);
        }

        private static async Task<CustomProtocolDTO> SendRequestAsync(StreamWriter writer, StreamReader reader, CustomProtocolDTO request)
        {
            string requestString = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                MaxDepth = 128
            });
            await writer.WriteLineAsync(requestString.Length.ToString());
            await writer.WriteLineAsync(requestString);
            var response = await HandleServerResponse(reader);
            return response;
        }

        private static async Task<CustomProtocolDTO> HandleServerResponse(StreamReader reader)
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
                    return response;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                }

            }
        }

        private static (string, string) GetInputForLogin()
        {
            string employeeId = string.Empty;
            while (true)
            {
                Console.WriteLine("Enter employeeId:");
                employeeId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(employeeId))
                {
                    Console.WriteLine("Employee ID cannot be empty. Please enter a valid employee ID.");
                    continue;
                }

                if (!int.TryParse(employeeId, out _))
                {
                    Console.WriteLine("Employee ID must be numeric. Please enter a valid employee ID.");
                    continue;
                }

                break;
            }
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();

            return (employeeId, name);
        }

        private static async Task HandleAction(CustomProtocolDTO response)
        {
            switch (response.Action)
            {
                case "SomeAction":
                    break;
                // Add cases for other actions
                default:
                    FormatJson(response.Response);
                    break;
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
                        currentLine += new string(' ', indentLevel * 4);
                    }
                }
                else
                {
                    currentLine += c;
                }
            }

            Console.WriteLine(currentLine);
        }
    }
}