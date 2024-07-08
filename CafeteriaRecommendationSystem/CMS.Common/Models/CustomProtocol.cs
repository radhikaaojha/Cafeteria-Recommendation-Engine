using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class CustomProtocol
    {
        public string Payload { get; set; }
        public string Action { get; set; }
        public string Response { get; set; }
        public string UserId { get; set; }
    }

}
