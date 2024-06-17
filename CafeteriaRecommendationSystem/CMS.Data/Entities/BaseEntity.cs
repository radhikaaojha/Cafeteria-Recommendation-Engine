using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedDateTime {  get; set; }
        public DateTime ModifiedDateTime {  get; set; }

    }
}
