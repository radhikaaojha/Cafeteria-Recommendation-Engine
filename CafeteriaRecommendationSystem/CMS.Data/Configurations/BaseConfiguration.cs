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
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedDateTime).HasColumnType("datetime2(0)")
            .HasDefaultValueSql("getdate()");
            builder.Property(x => x.ModifiedDateTime).HasColumnType("datetime2(0)")
            .HasDefaultValueSql("getdate()");
        }
    }
}
