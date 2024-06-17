using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class MealTypeConfiguration : BaseConfiguration<MealType>
    {
        public override void Configure(EntityTypeBuilder<MealType> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasMany(ft => ft.WeeklyMenu)
            .WithOne(c => c.MealType)
            .HasForeignKey(c => c.MealTypeId);
        }
    }
}
