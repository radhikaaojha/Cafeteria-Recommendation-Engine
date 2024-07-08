using Client.Services;
using CMS.Common.Enums;
using CMS.Common.Models;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public static class ClientRequestProcessor
    {
        public static async Task ProcessClientRequests(LoginResponse response, StreamWriter writer, StreamReader reader, TcpClient client)
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
                var serverCommunicationService = new ServerCommunicationService(writer, reader);
                var result = await serverCommunicationService.SendRequestAsync(writer, reader, request);
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

        private static async Task HandleAction(CustomProtocolDTO response)
        {
            try
            {
                switch (response.Action)
                {
                    case "BrowseMenu":
                        ClientResponseHandler.BrowseMenu(response.Response);
                        break;
                    case "TopRecommendations":
                        ClientResponseHandler.ShowTopRecommendations(response.Response);
                        break;
                    case "ViewNotifications":
                        ClientResponseHandler.ShowNotifications(response.Response);
                        break;
                    case "ViewVotes":
                        ClientResponseHandler.ShowVotesForFoodItem(response.Response);
                        break;
                    case "ViewRolledOutItems":
                        ClientResponseHandler.ShowDailyMenu(response.Response);
                        break;
                    case "ViewTodaysMenu":
                        ClientResponseHandler.ShowDailyMenu(response.Response);
                        break;
                    case "ViewDiscardList":
                        ClientResponseHandler.ShowDiscardFoodItemList(response.Response);
                        break;
                    default:
                        Console.WriteLine(response.Response);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

      
    }
}
