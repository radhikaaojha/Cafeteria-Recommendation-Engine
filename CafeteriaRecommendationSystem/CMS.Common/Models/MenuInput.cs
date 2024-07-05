using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensorflow;

namespace CMS.Common.Models
{
    public class MenuInput
    {
        public List<string> Breakfast { get; set; } = new();
        public List<string> Lunch { get; set; } = new();
        public List<string> Dinner {  get; set; } = new();
    }
}
