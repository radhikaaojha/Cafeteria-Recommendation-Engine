using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class AppActivityLog : BaseEntity
    {
        [Key]
        [StringLength(100)]
        public string ActionName { get; set; }

        public DateTime? Value { get; set; }
    }
}
