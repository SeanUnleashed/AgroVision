using AgroVision.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVision.Web.Data
{
    public class AgroVisionDbContext : DbContext
    {
        public AgroVisionDbContext(DbContextOptions<AgroVisionDbContext> options) : base(options)
        {
        }

        public DbSet<UserCalculation> UserCalculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //indexes

            modelBuilder.Entity<UserCalculation>()
                .HasIndex(x => x.UserId);

            //foreign keys
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AgroVisionDbContext>
    {
        public AgroVisionDbContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AgroVisionDbContext>();
            var connectionString = configuration.GetConnectionString("AgroVisionConnection");
            builder.UseSqlServer(connectionString);
            return new AgroVisionDbContext(builder.Options);
        }
    }
}
