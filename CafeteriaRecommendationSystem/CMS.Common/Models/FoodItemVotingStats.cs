﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class FoodItemVotingStats
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public int NumberOfVotes { get; set; }
        public string MealType { get; set; }
    }
}
