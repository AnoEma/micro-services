namespace CustomerService.Api.Endpoint;

public static class CustomerEndpoint
{
    public static void AddEndpoints(WebApplication app)
    {
        app.MapGet("heath", () =>
        {
            return "ok";
        });
    }
}