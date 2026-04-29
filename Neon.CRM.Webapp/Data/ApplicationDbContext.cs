using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.Webapp.Data.Models;

namespace Neon.CRM.Webapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Agent>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<VacationPackage> VacationPackages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VacationPackage>().HasData(
                new VacationPackage
                {
                    Id = 1,
                    Title = "Beach Paradise",
                    Description = "Enjoy a week in a tropical paradise with white sandy beaches and crystal-clear waters.",
                    Price = 1999.99m,
                    DurationInDays = 7,
                },
                new VacationPackage
                {
                    Id = 2,
                    Title = "Mountain Adventure",
                    Description = "Experience the thrill of mountain climbing and hiking in breathtaking landscapes.",
                    Price = 1499.99m,
                    DurationInDays = 5,
                },
                new VacationPackage
                {
                    Id = 3,
                    Title = "City Explorer",
                    Description = "Discover the vibrant culture and history of a bustling city with guided tours and activities.",
                    Price = 999.99m,
                    DurationInDays = 3,
                }
                );

            builder.Entity<Agent>().HasData(
    new Agent
    {
        Id = "agent1",
        UserName = "agent1",
        NormalizedUserName = "AGENT1",
        Email = "agent1@example.com",
        NormalizedEmail = "AGENT1@EXAMPLE.COM",
        EmailConfirmed = false,
        FirstName = "AgentOne",
        LastName = "Hello1",
        SecurityStamp = "STAMP1",  // ✅ Static string (doesn't need to be GUID format)
        ConcurrencyStamp = "CONCUR1"  // ✅ Static string
    },
    new Agent
    {
        Id = "agent2",
        UserName = "agent2",
        NormalizedUserName = "AGENT2",
        Email = "agent2@example.com",
        NormalizedEmail = "AGENT2@EXAMPLE.COM",
        EmailConfirmed = false,
        FirstName = "AgentTwo",
        LastName = "Hello2",
        SecurityStamp = "STAMP2",
        ConcurrencyStamp = "CONCUR2"
    },
    new Agent
    {
        Id = "agent3",
        UserName = "agent3",
        NormalizedUserName = "AGENT3",
        Email = "agent3@example.com",
        NormalizedEmail = "AGENT3@EXAMPLE.COM",
        EmailConfirmed = false,
        FirstName = "AgentThree",
        LastName = "Hello3",
        SecurityStamp = "STAMP3",
        ConcurrencyStamp = "CONCUR3"
    });

            builder.Entity<Customer>().HasData(
               new Customer
               {
                   Id = 1,
                   FirstName = "Sammyboy",
                   LastName = "Quarter",
                   Email = "sammyboy.quarter@example.com",
                   PhoneNumber = "123-456-7890",
                   Address = "123 Beach Paradise Lane",
                   AgentId = "agent1"
               },
               new Customer
               {
                   Id = 2,
                   FirstName = " Adventure",
                   LastName = "Experience",
                   Email = "mountain.adventure@example.com",
                   PhoneNumber = "987-654-3210",
                   Address = "456 Mountain Adventure Lane",
                   AgentId = "agent2"
               },
               new Customer
               {
                   Id = 3,
                   FirstName = "Explorer",
                   LastName = "Discover",
                   Email = "city.explorer@example.com",
                   PhoneNumber = "555-555-5555",
                   Address = "789 City Explorer Lane",
                   AgentId = "agent3"
               }
               );
        }
    }
}
