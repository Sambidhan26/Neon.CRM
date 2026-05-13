using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Neon.CRM.Webapp.Data.Models;
using System.Security.Claims;

namespace Neon.CRM.Webapp.Providers;

public class CustomUserClaimPrincipleFactory:UserClaimsPrincipalFactory<Agent>
{
    public CustomUserClaimPrincipleFactory(UserManager<Agent> userManager,
        IOptions<IdentityOptions> optionsAccessor)
        :base(userManager,optionsAccessor)
    {

    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Agent user)
    {

        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("TenantConnectionString", user.TenantConnectionId ?? string.Empty));
        return identity;
    }
}
