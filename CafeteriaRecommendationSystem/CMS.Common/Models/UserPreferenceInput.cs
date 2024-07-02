using CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class UserPreferenceInput
    {
        public FoodCharacterstic CharacteristicId { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }
    }
}
