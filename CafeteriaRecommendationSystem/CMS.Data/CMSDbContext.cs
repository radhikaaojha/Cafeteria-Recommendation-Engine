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

        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<FoodItemAvailabilityStatus> FoodItemAvailabilityStatus { get; set; }
        public DbSet<FoodItemFeedback> FoodItemFeedback { get; set; }
        public DbSet<FoodItemType> FoodItemType { get; set; }
        public DbSet<MealType> MealType { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WeeklyMenu> WeeklyMenu { get; set; }
        public DbSet<AppActivityLog> AppActivityLog { get; set; }
        public DbSet<DetailedFoodItemFeedback> DetailedFoodItemFeedback { get; set; }
        public DbSet<FoodItemCharacteristic> FoodItemCharacteristic { get; set; }
        public DbSet<FoodItemCharactersticMapping> FoodItemCharactersticMapping { get; set; }
        public DbSet<UserPreference> UserPreference { get; set; }

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
            modelBuilder.ApplyConfiguration(new DetailedFoodItemFeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new AppActivityLogConfiguration());
            modelBuilder.ApplyConfiguration(new FoodItemCharactersticConfiguration());
            modelBuilder.ApplyConfiguration(new FoodItemCharactersticMappingConfiguration());
            modelBuilder.ApplyConfiguration(new UserPreferenceConfiguration());
            modelBuilder.Entity<Role>().HasData(SeedData.GetRoles());
            modelBuilder.Entity<NotificationType>().HasData(SeedData.GetNotificationTypes());
            modelBuilder.Entity<MealType>().HasData(SeedData.GetMealTypes());
            modelBuilder.Entity<FoodItemAvailabilityStatus>().HasData(SeedData.GetFoodItemAvailabilityStatus());
            modelBuilder.Entity<FoodItemType>().HasData(SeedData.GetFoodItemTypes());
            modelBuilder.Entity<User>().HasData(SeedData.GetUsers());
            modelBuilder.Entity<FoodItem>().HasData(SeedData.GetFoodItems());
            modelBuilder.Entity<FoodItemCharacteristic>().HasData(SeedData.GetFoodItemCharacterstic());
            modelBuilder.Entity<FoodItemCharactersticMapping>().HasData(SeedData.GetFoodItemCharactersticMapping());
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
    }

}
