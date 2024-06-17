using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class FoodItemAvailabilityStatusConfiguration : BaseConfiguration<FoodItemAvailabilityStatus>
    {
        public override void Configure(EntityTypeBuilder<FoodItemAvailabilityStatus> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasMany(ft => ft.FoodItem)
            .WithOne(c => c.FoodItemAvailabilityStatus)
            .HasForeignKey(c => c.StatusId);
        }
    }
}
