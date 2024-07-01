using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class FoodItemCharacteristic : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FoodItemCharactersticMapping> FoodItemCharactersticMapping { get; set; }
        public List<UserPreference> UserPreference { get; set; }
    }

}
