using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManagementServer
{
    public class ServerResponseHandler
    {
        public string CreateResponseForClient(string responseData)
        {
            var customProtocolResponse = JsonSerializer.Deserialize<CustomProtocolDTO>(responseData);
            return SerializeResponse(customProtocolResponse);
        }

        private string SerializeResponse(CustomProtocolDTO response)
        {
            return JsonSerializer.Serialize(response);
        }
    }


}
