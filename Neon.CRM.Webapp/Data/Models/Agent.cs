using Microsoft.AspNetCore.Identity;

namespace Neon.CRM.Webapp.Data.Models
{
    public class Agent: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? TenantConnectionId { get; set; }
        // Navigation property
        public ICollection<Customer> Customers { get; set; } = [];

    }
}
