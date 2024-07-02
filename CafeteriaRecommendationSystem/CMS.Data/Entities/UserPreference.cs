using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class UserPreference : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CharacteristicId { get; set; }
        public int Priority { get; set; }
        public FoodItemCharacteristic FoodItemCharacteristic { get; set; }
    }

}
