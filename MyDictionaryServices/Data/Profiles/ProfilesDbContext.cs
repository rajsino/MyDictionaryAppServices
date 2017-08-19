using Microsoft.EntityFrameworkCore;
using MyDictionaryServices.Models.PrepareTest;
using MyDictionaryServices.Models.Profiles;

namespace MyDictionaryServices.Data.Profiles
{
    public class ProfilesDbContext : DbContext
    {
        public ProfilesDbContext(DbContextOptions<ProfilesDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetStringMaxLengthConvention(255);
            
            modelBuilder.Entity<UserProfile>()
                .HasOne<User>(c => c.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<UserProfile>(p => p.UserId);
            
            modelBuilder.Entity<User>()
                .Property(u => u.TenantId).
                ForSqlServerHasDefaultValue(0);

            modelBuilder.Entity<Tenant>()
                .HasMany<User>(t => t.Users)
                .WithOne(u => u.Tenant)
                .HasForeignKey(u => u.TenantId);

            modelBuilder.Entity<TestResults>()
                .ForSqlServerToTable("TestResults");
        }

        public DbSet<UserProfile> Profiles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<TestResults> TestResults { get; set; }
    }
}
