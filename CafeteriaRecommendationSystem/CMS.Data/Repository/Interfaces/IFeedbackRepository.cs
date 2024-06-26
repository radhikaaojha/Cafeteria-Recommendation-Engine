﻿using CMS.Data.Entities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository.Interfaces
{
    public interface IFeedbackRepository : ICrudBaseRepository<FoodItemFeedback>
    {
        Task SubmitDetailedFeedback(DetailedFoodItemFeedback detailedFoodItemFeedback);
    }
}
