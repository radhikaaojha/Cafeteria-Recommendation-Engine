using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Data.Configurations
{
    public class FoodItemTypeConfiguration : BaseConfiguration<FoodItemType>
    {
        public override void Configure(EntityTypeBuilder<FoodItemType> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasMany(ft => ft.FoodItem)
            .WithOne(c => c.FoodItemType)
            .HasForeignKey(c => c.FoodItemTypeId);
        }
    }
}
