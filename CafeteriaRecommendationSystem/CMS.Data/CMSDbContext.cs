using CMS.Data.Configurations;
using CMS.Data.Entities;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Data_Access_Layer
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext() : base() { }
        public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodItemAvailabilityStatus> FoodItemAvailabilityStatuses { get; set; }
        public DbSet<FoodItemFeedback> FoodItemFeedbacks { get; set; }
        public DbSet<FoodItemType> FoodItemTypes { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeeklyMenu> WeeklyMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FoodItemConfiguration());
            modelBuilder.ApplyConfiguration(new FoodItemAvailabilityStatusConfiguration());
            modelBuilder.ApplyConfiguration(new FoodItemFeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new FoodItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MealTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WeeklyMenuConfiguration());
            modelBuilder.Entity<Role>().HasData(SeedData.GetRoles());
            modelBuilder.Entity<NotificationType>().HasData(SeedData.GetNotificationTypes());
            modelBuilder.Entity<MealType>().HasData(SeedData.GetMealTypes());
            modelBuilder.Entity<FoodItemAvailabilityStatus>().HasData(SeedData.GetFoodItemAvailabilityStatus());
            modelBuilder.Entity<FoodItemType>().HasData(SeedData.GetFoodItemTypes());
            //base.OnModelCreating(modelBuilder);
        }

        private void SetAuditProperties()
        {
            List<EntityEntry> modifiedOrAddedEntities = this.ChangeTracker.Entries()
                          .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added)
                          .Where(x => x.Entity is BaseEntity).ToList();

            foreach (var entry in modifiedOrAddedEntities)
            {
                var entity = entry.Entity as BaseEntity;

                if (entity != null)
                {
                    var excludeProperties = entry.Context.Entry(entry.Entity);
                    excludeProperties.Property(nameof(BaseEntity.CreatedDateTime)).IsModified = false;
                    entity.ModifiedDateTime = DateTime.Now;
                }
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetAuditProperties();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public class DateTimeToLocalConverter : ValueConverter<DateTime, DateTime>
        {
            public DateTimeToLocalConverter() : base(Serialize, Deserialize, null)
            {
            }

            private static Expression<Func<DateTime, DateTime>> Deserialize =
                    x => x.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(x, DateTimeKind.Local) : x;

            private static Expression<Func<DateTime, DateTime>> Serialize = x => x.ToUniversalTime();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<DateTime>()
                .HaveConversion<DateTimeToLocalConverter>();
        }
    }

}
