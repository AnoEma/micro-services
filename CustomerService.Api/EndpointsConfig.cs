using CustomerService.Api.Endpoint;

namespace CustomerService.Api;

public static class EndpointsConfig
{
    public static void AddEndpoints(this WebApplication app)
    {
        CustomerEndpoint.AddEndpoints(app);
    }
}
