using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class ViewNotification
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
