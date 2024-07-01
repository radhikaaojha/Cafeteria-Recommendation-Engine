using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Data.Configurations
{
    public class FoodItemConfiguration : BaseConfiguration<FoodItem>
    {
        public override void Configure(EntityTypeBuilder<FoodItem> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(e => e.FoodItemFeedback)
           .WithOne(a => a.FoodItem)
           .HasForeignKey(e => e.FoodItemId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.DetailedFoodItemFeedback)
           .WithOne(a => a.FoodItem)
           .HasForeignKey(e => e.FoodItemId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.WeeklyMenu)
          .WithOne(a => a.FoodItem)
          .HasForeignKey(e => e.FoodItemId)
          .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
