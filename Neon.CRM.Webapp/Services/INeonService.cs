using Neon.CRM.Webapp.Services.Response;

namespace Neon.CRM.Webapp.Services.Request
{
    public interface INeonService
    {
        Task<BranchCreateResponse> CreateBranchAsync(string tenantName);
    }
}