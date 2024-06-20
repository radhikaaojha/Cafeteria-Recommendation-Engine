using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class DailyMenuInput
    {
        public List<string> Breakfast {  get; set; }
        public List<string> Lunch {  get; set; }
        public List<string> Dinner {  get; set; }
    }
}
