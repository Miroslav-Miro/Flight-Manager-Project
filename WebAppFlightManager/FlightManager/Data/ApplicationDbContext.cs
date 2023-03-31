namespace FlightManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FlightManager.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    // Add-Migration InitialMigration -OutputDir Migrations  -Project FlightManager.Data -StartupProject FlightManager.Web

    // Update-Database -Project FlightManager.Data -StartupProject FlightManager.Web
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
