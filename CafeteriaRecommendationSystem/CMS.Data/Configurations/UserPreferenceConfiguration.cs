using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class UserPreferenceConfiguration : BaseConfiguration<UserPreference>
    {
        public override void Configure(EntityTypeBuilder<UserPreference> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasOne(up => up.User)
            .WithMany(u => u.UserPreference)
            .HasForeignKey(up => up.UserId);

            builder.HasOne(up => up.FoodItemCharacteristic)
                .WithMany(fc => fc.UserPreference)
                .HasForeignKey(up => up.CharacteristicId);
        }
    }
}
