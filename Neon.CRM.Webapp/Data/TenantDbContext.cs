using Microsoft.EntityFrameworkCore;
using Neon.CRM.Webapp.Data.Models;
using System.CodeDom;

namespace Neon.CRM.Webapp.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options)
            : base(options)
        {
        }
        // Define tenant-specific DbSets here, e.g.:
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<VacationPackage> VacationPackages { get; set; } = null!;
    }

    public class TenantDbContextFactory(IHttpContextAccessor _httpContextAccessor)
    {

        public TenantDbContext CreateDbContext()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var connectionString = user?.FindFirst("ConnectionString")?.Value;

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found for the current user.");
            }

            var optionBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionBuilder.UseNpgsql();
            return new TenantDbContext(optionBuilder.Options);
        }

    }
}
