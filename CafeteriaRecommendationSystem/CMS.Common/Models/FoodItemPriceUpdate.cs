using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMS.Common.Models
{
    public class FoodItemPriceUpdate
    {
        public int FoodItemId { get; set; }
        public decimal Price { get; set; }

        public bool IsValid()
        {
            if (Price <= 0)
                return false;

            return true;
        }
    }


}
