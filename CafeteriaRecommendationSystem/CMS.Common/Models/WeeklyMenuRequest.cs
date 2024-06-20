using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class WeeklyMenuRequest
    {
        public bool IsSelected { get; set; } = false;
        public int MealTypeId { get; set; }
        public int FoodItemId { get; set; }
    }
}
