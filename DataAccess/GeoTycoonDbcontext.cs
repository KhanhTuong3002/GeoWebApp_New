using BusinessObject.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DataAccess
{
    public partial class GeoTycoonDbcontext : IdentityDbContext
    {
        public GeoTycoonDbcontext() { }

        public GeoTycoonDbcontext(DbContextOptions<GeoTycoonDbcontext> options) : base(options) { }

        public virtual DbSet<Question> Questions { get; init; } = default!;
        public virtual DbSet<Answer> Answers { get; init; } = default!;
        public virtual DbSet<Tracking> Trackings { get; init; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                server => server.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.ApplyConfigurationsFromAssembly(typeof(GeoTycoonDbcontext).Assembly);
        }
    }
}
