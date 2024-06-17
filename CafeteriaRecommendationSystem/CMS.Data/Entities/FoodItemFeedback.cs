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
    public class FoodItemFeedback : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }  
        public User User { get; set; }
    }
}
