using CarNumberGuideApp.RDB.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CarNumberGuideApp.RDB
{
    public class AppDbContext : DbContext
    {
        //  private readonly IConfiguration _configuration;
        public DbSet<DbRegistrationNumber> RegistrationNumbers { get; set; }
        public DbSet<DbRegionNumber> RegionNumbers { get; set; }
        public DbSet<DbRegion> Regions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbRegion>()
          .Property(r => r.Name)
          .IsRequired() // Требование NOT NULL
          .HasMaxLength(100); // Опционально, задает максимальную длину имени

            modelBuilder.Entity<DbRegion>()
                .HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}


