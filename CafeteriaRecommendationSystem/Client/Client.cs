using CMS.Common.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

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
                await Authenticate(writer,reader);
                do
                {
                    Console.WriteLine("Enter your request:");
                    await ReadInput(writer,reader);
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

    private static async Task Authenticate(StreamWriter writer, StreamReader reader)
    {
        CustomProtocolDTO authRequest = new CustomProtocolDTO
        {
            Headers = new Dictionary<string, string>
                {
                    {"Action","Auth" }
                },
            Payload = new Dictionary<string, string>
                {
                    { "Request", JsonSerializer.Serialize(new {EmployeeId ="", Name ="Radhika"}) }
                }
        };

        await SendRequestAsync(writer,reader, authRequest);
    }

    private static async Task ReadInput(StreamWriter writer, StreamReader reader)
    {
        var requestString = Console.ReadLine();
        string[] parts = requestString.Split(' ');//(Action)Admin 1-Price:50 Name:Pizza
        CustomProtocolDTO request = new CustomProtocolDTO
        {
            Headers = new Dictionary<string, string>
           {
               {"Action",parts[0] }
           },
            Payload = new Dictionary<string, string>
           {
               { "Request", JsonSerializer.Serialize(parts[1]) }
           }
        };
        await SendRequestAsync(writer,reader, request);
    }
    //handle req handle response send req send response
    //userId, action, ->middleware //request hanlder ->delegate action method navigating-> to actual method using summary
    private static async Task SendRequestAsync(StreamWriter writer, StreamReader reader,CustomProtocolDTO request)
    {
        {
            string requestString = JsonSerializer.Serialize(request);//protocl format
            await writer.WriteLineAsync(requestString.Length.ToString());
            await writer.WriteLineAsync(requestString);

            await HandleServerResponse(reader);
        }
    }

    private static async Task HandleServerResponse(StreamReader reader)
{
    while (true)
    {
        string lengthString = await reader.ReadLineAsync();
        if (string.IsNullOrEmpty(lengthString))
        {
            break; // No more data to read
        }

        if (!int.TryParse(lengthString, out int dataLength))
        {
            Console.WriteLine("Invalid data length received from server.");
            continue; // Skip this response and try to read the next one
        }

        char[] buffer = new char[dataLength];
        int bytesRead = await reader.ReadAsync(buffer, 0, dataLength);
        if (bytesRead != dataLength)
        {
            Console.WriteLine("Unexpected data length received from server.");
            continue; // Skip this response and try to read the next one
        }

        string responseData = new string(buffer);
        try
        {
            CustomProtocolDTO response = JsonSerializer.Deserialize<CustomProtocolDTO>(responseData);
            Console.WriteLine($"Response: {response.Response["Result"]}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Failed to deserialize JSON: {ex.Message}");
        }
    }
}
}
