using CMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class WeeklyMenu : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsSelected { get; set; } 
        public int NumberOfVotes { get; set; }
        public int MealTypeId { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public MealType MealType { get; set; }  
    }
}
