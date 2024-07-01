using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Data.Configurations
{
    public class FoodItemCharactersticMappingConfiguration : BaseConfiguration<FoodItemCharactersticMapping>
    {
        public override void Configure(EntityTypeBuilder<FoodItemCharactersticMapping> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasOne(fic => fic.FoodItem)
           .WithMany(fi => fi.FoodItemCharactersticMapping)
           .HasForeignKey(fic => fic.FoodItemId);

            builder.HasOne(fic => fic.FoodItemCharacteristic)
                .WithMany(fc => fc.FoodItemCharactersticMapping)
                .HasForeignKey(fic => fic.CharacteristicId);
        }
    }
}
