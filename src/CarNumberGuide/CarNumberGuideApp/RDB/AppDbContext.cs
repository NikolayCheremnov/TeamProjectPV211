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
    }
}


