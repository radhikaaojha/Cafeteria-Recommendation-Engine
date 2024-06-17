using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class AddFoodItem
    {
        public string Name { get; set; }
        public int StatusId { get; set; } = (int)Status.Available;
        public decimal Price { get; set; }
        public int FoodItemTypeId { get; set; }
    }
}
