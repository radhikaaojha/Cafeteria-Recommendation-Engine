using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.Entities
{
    public class DetailedFoodItemFeedback : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodItemId { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public FoodItem FoodItem { get; set; }
        public User User { get; set; }
    }
}
