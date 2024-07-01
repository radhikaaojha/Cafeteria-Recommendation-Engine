using CMS.Data.Entities;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class DetailedFoodItemFeedbackConfiguration : BaseConfiguration<DetailedFoodItemFeedback>
    {
        public override void Configure(EntityTypeBuilder<DetailedFoodItemFeedback> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }
    }
}
