using BookStore.Api.Endpoint;

namespace BookStore.Api;

public static class EndpointConfig
{
    public static void AddEndpoints(this WebApplication app)
    {
        BookStoreEndpoint.AddEndpoints(app);
    }
}
