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
    public class AppActivityLogConfiguration : BaseConfiguration<AppActivityLog>
    {
        public override void Configure(EntityTypeBuilder<AppActivityLog> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.ActionName);
        }
    }
}
