namespace FlightManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FlightManager.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    // Add-Migration InitialMigration -OutputDir Migrations  -Project FlightManager.Data -StartupProject FlightManager.Web

    // Update-Database -Project FlightManager.Data -StartupProject FlightManager.Web
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            User admin = CreateUser("admin@abv.bg");
            User user = CreateUser("miroslav@abv.bg");

            builder.Entity<User>().HasData(admin);

            builder.Entity<User>().HasData(user);


            IdentityRole adminRole = CreateRole("Admin");
            IdentityRole userRole = CreateRole("User");

            builder.Entity<IdentityRole>(
                option =>
                {
                    option.HasData(new IdentityRole[]
                    {
                        adminRole,
                        userRole,
                    }
                    );
                });
        }

        private User CreateUser(string email, string password = "123456")
        {
            List<string> firstName = new List<string>() { "John", "Alex", "Jane", "Jack" };
            List<string> lastName = new List<string>() { "Johnson", "Alexandrov" };
            Random random = new Random();
            var hasher = new PasswordHasher<IdentityUser>();
            //Create user
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                NormalizedUserName = email,
                Email = email,
                NormalizedEmail = email,
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                FirstName = firstName[random.Next(0, firstName.Count)],
                LastName = lastName[random.Next(0, lastName.Count)]
            };
            return user;
        }

        private static IdentityRole CreateRole(string roleName)
        {
            return new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = roleName, NormalizedName = roleName };
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
