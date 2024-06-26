﻿using Domain.Aggregate;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"), b => b.MigrationsAssembly("API"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define Model Relationship
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setup>().HasData(
            new Setup
            {
                BusinessName = "Group 4",
                BusinessId = "Cohort-001",
                BusinessLogo = "Logo",
                BusinessColorCode = "#007766",
                BusinessLogoUrl = "Http",
                CreatedBy = "Kene",
                ModifiedBy = "Kene"
            }
        );
        }
        public DbSet<User> User { get; set; }
        public DbSet<Setup> Setup { get; set; }

    }
}
