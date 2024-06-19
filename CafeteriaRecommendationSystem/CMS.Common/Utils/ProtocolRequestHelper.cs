using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Common.Utils
{
    public class ProtocolRequestHelper
    {
        public static string SerializeMessage(CustomProtocolDTO message)
        {
            return JsonSerializer.Serialize(message);
        }

        public static CustomProtocolDTO DeserializeMessage(string message)
        {
            return JsonSerializer.Deserialize<CustomProtocolDTO>(message);
        }
    }
}
