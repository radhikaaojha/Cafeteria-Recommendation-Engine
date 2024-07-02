using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class UserActivityLog : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }

    }
}
