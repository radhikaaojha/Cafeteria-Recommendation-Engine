using CMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class FoodItem : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public int StatusId { get; set; }
        public decimal Price { get; set; }
        public int FoodItemTypeId {  get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; } = string.Empty;
        public decimal SentimentScore { get; set; }
        public FoodItemAvailabilityStatus FoodItemAvailabilityStatus { get; set; }
        public FoodItemType FoodItemType { get; set; }
        public List<FoodItemFeedback> FoodItemFeedback { get; set; }
        public List<DetailedFoodItemFeedback> DetailedFoodItemFeedback { get; set; }
        public List<WeeklyMenu> WeeklyMenu { get; set; }
        public List<FoodItemCharactersticMapping> FoodItemCharactersticMapping { get; set; }
    }
}
