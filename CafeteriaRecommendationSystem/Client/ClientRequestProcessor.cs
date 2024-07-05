using Client.Services;
using CMS.Common.Enums;
using CMS.Common.Models;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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
