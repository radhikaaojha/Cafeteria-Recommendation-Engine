using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class CustomProtocolDTO
    {
        public Dictionary<string, string> Payload { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Response { get; set; }
    }

}
