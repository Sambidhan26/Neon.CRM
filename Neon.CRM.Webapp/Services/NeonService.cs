using Neon.CRM.Webapp.Services.Response;

namespace Neon.CRM.Webapp.Services.Request;

public class NeonService : INeonService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    public NeonService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;


        _httpClient.BaseAddress = new Uri(_config["NeonApi:BaseUrl"] ?? throw new InvalidOperationException("NeonApiBaseUrl is not configured."));
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config["NeonApi:ApiKey"]
            ?? throw new InvalidOperationException("NeonApiApiKey is not configured."));
    }

    public async Task<BranchCreateResponse> CreateBranchAsync(string tenantName)
    {
        var projectId = _config["NeonApi:ProjectId"] ?? throw new InvalidOperationException("NeonApiProjectId is not configured.");

        var requestBody = new BranchCreateRequest
        {
            branch = new Branch
            {
                parent_id = _config["NeonApi:ParentBranchId"],
                name = $"tenant_{tenantName.ToLower()}",
                init_source = "schema-only"
            },
            endpoints = new[]
            {
                new Endpoint
                {
                    type = "read_write"
                }
            }
        };

        var response = await _httpClient.PostAsJsonAsync($"/v2/projects/{projectId}/branches", requestBody);

        if (response.IsSuccessStatusCode)
        {
            var branchResponse = await response.Content.ReadFromJsonAsync<BranchCreateResponse>();
            return branchResponse ?? throw new Exception("Branch ID not found in response.");
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to create branch. Status Code: {response.StatusCode}, Response: {errorContent}");
        }
    }
}


