using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Common.Utils
{
    public static class ProtocolResponseHelper
    {
        public static string CreateSuccessResponse(string response,string action)
        {
            var successResponse = new CustomProtocol
            {
                Response = response,
                Action = action
            };

            return JsonSerializer.Serialize(successResponse);
        }
        public static string CreateFailureResponse(string response)
        {
            var successResponse = new CustomProtocol
            {
                Response = response,
                Action = "Exception"
            };

            return JsonSerializer.Serialize(successResponse);
        }
    }
}
