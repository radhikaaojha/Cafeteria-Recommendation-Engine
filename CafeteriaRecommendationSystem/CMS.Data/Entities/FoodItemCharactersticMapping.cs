using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class FoodItemCharactersticMapping : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public int CharacteristicId { get; set; }
        public FoodItemCharacteristic FoodItemCharacteristic { get; set; }
    }
}
