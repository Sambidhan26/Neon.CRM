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
    }
}
