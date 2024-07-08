using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class ViewNextDayMenu
    {
        public List<RecommendedItem> Breakfast { get; set; } = new();
        public List<RecommendedItem> Lunch { get; set; } = new();
        public List<RecommendedItem> Dinner { get; set; } = new();
    }
}
