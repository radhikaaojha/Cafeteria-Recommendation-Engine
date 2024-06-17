using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class FoodItemFeedbackConfiguration : BaseConfiguration<FoodItemFeedback>
    {
        public override void Configure(EntityTypeBuilder<FoodItemFeedback> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }
    }
}
