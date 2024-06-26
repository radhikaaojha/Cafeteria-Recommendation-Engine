﻿using CafeteriaRecommendationSystem.Services.Interfaces;
using CafeteriaRecommendationSystem.Services;
using CMS.Data.Services.Interfaces;
using CMS.Data.Services;
using Common;
using Data_Access_Layer.Repository.Interfaces;
using Data_Access_Layer.Repository;
using Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CMS.Common.Utils;
using System;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Repository;
using Common.Utils;
using System.Net;
using Microsoft.Extensions.Logging;

namespace ManagementServer
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
       {
           builder
               .AddFilter((category, level) => false); 
       });
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            var host = Host.CreateDefaultBuilder()
              .ConfigureServices((context, services) =>
              {
                  ConfigureServices(services);
              })
              .Build();
            _serviceProvider = host.Services;
            var authTaskExecutor = _serviceProvider.GetRequiredService<AuthenticationTaskExecutor>();
            var adminTaskExecutor = _serviceProvider.GetRequiredService<AdminTaskExecutor>();
            var employeeTaskExecutor = _serviceProvider.GetRequiredService<EmployeeTaskExecutor>();
            var chefTaskExecutor = _serviceProvider.GetRequiredService<ChefTaskExecutor>();
            var serverResponseHandler = _serviceProvider.GetRequiredService<ServerResponseHandler>();
            var taskExecutorFactory = _serviceProvider.GetRequiredService<TaskExecutorFactory>();
            var clientRequestProcessor = new ClientRequestProcessor(taskExecutorFactory, serverResponseHandler);
            var server = new Server(clientRequestProcessor);
            await server.StartServer();
        }

        private static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CMSDbContext>(options => options.UseSqlServer(AppConstants.ConnectionString).UseLoggerFactory(loggerFactory));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(ICrudBaseRepository<>), typeof(CrudBaseRepository<>));
            services.AddScoped(typeof(ICrudBaseService<>), typeof(CrudBaseService<>));
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFoodItemService, FoodItemService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IWeeklyMenuService, WeeklyMenuService>();
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            services.AddScoped<IAppActivityLogRepository, AppActivityLogRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<TaskExecutorFactory>();
            services.AddScoped<AuthenticationTaskExecutor>();
            services.AddScoped<AdminTaskExecutor>();
            services.AddScoped<ServerResponseHandler>();
            services.AddScoped<ChefTaskExecutor>();
            services.AddScoped<EmployeeTaskExecutor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services.BuildServiceProvider();
        }
    }
}
