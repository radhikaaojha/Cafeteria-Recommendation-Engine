using CMS.Common.Enums;
using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    public static class AuthenticateService
    {
        public static async Task<CustomProtocol> Authenticate(StreamWriter writer, StreamReader reader)
        {
            var (employeeId, name) = GetInputForLogin();

            CustomProtocol authRequest = new CustomProtocol
            {
                UserId = employeeId,
                Action = Actions.Auth.ToString(),
                Payload = JsonSerializer.Serialize(new { EmployeeId = employeeId, Name = name })
            };
            var serverCommunicationService = new ServerCommunicationService(writer, reader);
            return await serverCommunicationService.SendRequestAsync(writer, reader, authRequest);
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

    }
}
