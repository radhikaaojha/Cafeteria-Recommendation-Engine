using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class FoodItemCharactersticConfiguration : BaseConfiguration<FoodItemCharacteristic>
    {
        public override void Configure(EntityTypeBuilder<FoodItemCharacteristic> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }
    }
}
