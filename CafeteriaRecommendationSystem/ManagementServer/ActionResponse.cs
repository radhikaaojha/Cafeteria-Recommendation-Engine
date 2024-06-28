using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer
{
    public class ActionResponse
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public string ErrorMessage { get; set; }
    }
}
