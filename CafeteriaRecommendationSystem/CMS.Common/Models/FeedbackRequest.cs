using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class FeedbackRequest
    {
        public int UserId { get; set; }
        public int FoodItemId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

    }
}
