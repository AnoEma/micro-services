
using BookStore.Api.Model;
using BookStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Endpoint;

public static class BookStoreEndpoint
{
    public static void AddEndpoints(WebApplication app)
    {
        app.MapGet("api/bookstore/heath", () =>
        {
            return "ok";
        });

        app.MapGet("api/bookstore/{id}", async (
            [FromRoute] string id,
            [FromServices] IBookStoreService services,
            CancellationToken cancellation) =>
        {
            var customerId = new Guid(id);
            var result = await services.GetById(customerId, cancellation);

            return result;
        });

        app.MapPost("api/bookstore/create", async (
            [FromBody] BookStores body,
            [FromServices] IBookStoreService services,
            CancellationToken cancellation) =>
        {
            await services.Create(body, cancellation);
        });

        app.MapPut("api/bookstore/update", async (
           [FromBody] BookStores body,
           [FromServices] IBookStoreService services,
           CancellationToken cancellation) =>
        {
            await services.Update(body, cancellation);
        });

        app.MapGet("api/bookstore/all", async (
            [FromServices] IBookStoreService services,
            CancellationToken cancellation) =>
        {
            var result = await services.GetAll(cancellation);

            return result;
        });
    }
}