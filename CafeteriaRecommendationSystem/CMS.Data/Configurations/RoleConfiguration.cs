using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class RoleConfiguration : BaseConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasMany(ft => ft.User)
            .WithOne(c => c.Role)
            .HasForeignKey(c => c.RoleId);
        }
    }
}
