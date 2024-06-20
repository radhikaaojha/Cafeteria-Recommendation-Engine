using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class RecommendedItem
    {
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; } 
        public decimal SentimentScore { get; set; }
    }
}
