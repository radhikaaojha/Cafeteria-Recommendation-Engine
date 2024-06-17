using CafeteriaRecommendationSystem.Services;
using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
using CMS.Data.Services;
using CMS.Data.Services.Interfaces;
using Common.Enums;
using Common.Models;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ManagementServer
{
    class Server
    {
        private static List<TcpClient> _authenticatedClients = new List<TcpClient>();
        private static IServiceProvider _serviceProvider;

        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            //var startup = new Startup();
            //startup.ConfigureServices(services);
            var host = Host.CreateDefaultBuilder()
              .ConfigureServices((context, services) =>
              {
                  // Configure services
                  ConfigureServices(services);
              })
              .Build();
            _serviceProvider = host.Services;
            var roleBasedMenuService = _serviceProvider.GetRequiredService<IRoleBasedMenuService>();
            List<string> menuOptions = await roleBasedMenuService.ViewOptions(1);
            Console.ReadLine();
            /*var roleBasedMenuService = _serviceProvider.GetRequiredService<IRoleBasedMenuService>();
            var dbContext = _serviceProvider.GetRequiredService<CMSDbContext>();
            var userRepository = _serviceProvider.GetRequiredService<IUserRepository>();
            var authenticateService = _serviceProvider.GetRequiredService<IAuthenticateService>();

            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                //_connectedClients.Add(client);
                _ = Task.Run(() => HandleClientAsync(client));// authenticateService, roleBasedMenuService));
            }*/
        }

        private static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CMSDbContext>(options => options.UseSqlServer("Data Source=ITT-RADHIKA-O;Initial Catalog=CafeteriaManagementSystem;Integrated Security=True"));
            //services.AddScoped<CMSDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(ICrudBaseRepository<>), typeof(CrudBaseRepository<>));
            services.AddScoped(typeof(ICrudBaseService<>), typeof(CrudBaseService<>));
            services.AddScoped<IRoleBasedMenuService, RoleBasedMenuService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFoodItemService, FoodItemService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IWeeklyMenuService, WeeklyMenuService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services.BuildServiceProvider();
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;
                    StringBuilder requestBuilder = new StringBuilder();

                    // Read the full request
                    do
                    {
                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                    }
                    while (stream.DataAvailable);

                    string requestJson = requestBuilder.ToString();
                    Console.WriteLine($"Received JSON: {requestJson}");

                    CustomProtocolDTO protocolMessage;
                    try
                    {
                        protocolMessage = JsonSerializer.Deserialize<CustomProtocolDTO>(requestJson);
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"Failed to deserialize protocol message: {ex.Message}");
                        return;
                    }

                    if (protocolMessage.ProtocolType == "Auth")
                    {
                        var loginRequest = JsonSerializer.Deserialize<UserLogin>(protocolMessage.Payload);
                        var authenticateService = _serviceProvider.GetRequiredService<IAuthenticateService>();
                        var loginResponse = await authenticateService.Login(loginRequest);

                        string responsePayload = JsonSerializer.Serialize(loginResponse);
                        if (loginResponse.IsAuthenticated)
                        {
                            _authenticatedClients.Add(client);

                            var roleBasedMenuService = _serviceProvider.GetRequiredService<IRoleBasedMenuService>();
                            List<string> menuOptions = await roleBasedMenuService.ViewOptions(loginResponse.RoleId);
                            responsePayload = JsonSerializer.Serialize(new { loginResponse, menuOptions });
                        }

                        var responseProtocolMessage = new CustomProtocolDTO
                        {
                            SourceIp = "Server IP",
                            DestinationIp = "Client IP",
                            ProtocolType = "AuthResponse",
                            Payload = responsePayload
                        };

                        string responseJson = JsonSerializer.Serialize(responseProtocolMessage);
                        Console.WriteLine($"Sending JSON: {responseJson}");
                        byte[] responseBytes = Encoding.UTF8.GetBytes(responseJson);
                        await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    }
                    else if (_authenticatedClients.Contains(client))
                    {
                        // Handle other protocol types here
                    }
                    else
                    {
                        Console.WriteLine("Unauthenticated client trying to make a request.");
                        client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception handling client: {ex.Message}");
                client.Close();
            }
        }
    }
}