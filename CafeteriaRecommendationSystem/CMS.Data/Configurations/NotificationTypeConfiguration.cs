﻿using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Configurations
{
    public class NotificationTypeConfiguration : BaseConfiguration<NotificationType>
    {
        public override void Configure(EntityTypeBuilder<NotificationType> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.HasMany(ft => ft.Notification)
            .WithOne(c => c.NotificationType)
            .HasForeignKey(c => c.NotificationTypeId);
        }
    }
}
