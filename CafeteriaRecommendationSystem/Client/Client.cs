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
                    var response = (await AuthenticateService.Authenticate(writer, reader));
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(response.Response);
                    Console.WriteLine($"{loginResponse.Message}");
                    await ClientRequestProcessor.ProcessClientRequests(loginResponse, writer, reader, client);
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

       
 
    }
}