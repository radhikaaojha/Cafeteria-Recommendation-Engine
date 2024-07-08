using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class ViewFoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal SentimentScore { get; set; }
        public string AvailabilityStatus { get; set; }
        public string FoodItemType { get; set; }
    }
}
