using CMS.Common.Models;
using Common.Models;
using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class Client
{
    public static async Task Main(string[] args)
    {
        var client = new Client();

        var loginRequest = client.GetUserInput();
        var loginResponse = await client.SendLoginRequest(loginRequest);

        client.HandleLoginResponse(loginResponse);
    }

    public UserLogin GetUserInput()
    {
        Console.WriteLine("Enter Employee Id:");
        if (!int.TryParse(Console.ReadLine(), out int employeeId))
        {
            Console.WriteLine("Invalid Employee Id. Please enter a valid number.");
            Environment.Exit(0);
        }

        Console.WriteLine("Enter full name:");
        string fullName = Console.ReadLine();

        return new UserLogin { EmployeeId = employeeId, Name = fullName };
    }

    public async Task<(LoginResponse, string)> SendLoginRequest(UserLogin loginRequest)
    {
        var protocolMessage = new CustomProtocolDTO
        {
            SourceIp = "Client IP", // Set the actual client IP
            DestinationIp = "Server IP", // Set the actual server IP
            ProtocolType = "Auth",
            Payload = JsonSerializer.Serialize(loginRequest)
        };

        string requestJson = JsonSerializer.Serialize(protocolMessage);
        Console.WriteLine($"Sending JSON: {requestJson}");

        using (TcpClient client = new TcpClient("127.0.0.1", 8888))
        using (NetworkStream stream = client.GetStream())
        {
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

            byte[] buffer = new byte[4096];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Received JSON: {responseJson}");

            CustomProtocolDTO protocolResponse;
            try
            {
                protocolResponse = JsonSerializer.Deserialize<CustomProtocolDTO>(responseJson);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to deserialize protocol message: {ex.Message}");
                throw;
            }

            var response = JsonSerializer.Deserialize<Dictionary<string, object>>(protocolResponse.Payload);
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(response["loginResponse"].ToString());
            var menuOptions = response.ContainsKey("menuOptions") ? response["menuOptions"].ToString() : null;

            return (loginResponse, menuOptions);
        }
    }

    private void HandleLoginResponse((LoginResponse loginResponse, string menuOptions) response)
    {
        var (loginResponse, menuOptions) = response;

        if (loginResponse.IsSuccess)
        {
            Console.WriteLine("Login successful!");
            Console.WriteLine($"Menu Options: {menuOptions}");
            // Handle menu options based on role
        }
        else
        {
            Console.WriteLine($"Login failed: {loginResponse.Message}");
        }
    }
}
