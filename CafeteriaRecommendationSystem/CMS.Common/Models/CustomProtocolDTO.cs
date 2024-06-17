using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class CustomProtocolDTO
    {
        public string SourceIp { get; set; }
        public string DestinationIp { get; set; }
        public string ProtocolType { get; set; } // e.g., "Auth", "DataRequest"
        public string Payload { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }

}
