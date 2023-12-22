
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
            [FromServices] IBookStoreService services) =>
        {
            var customerId = new Guid(id);
            var result = await services.GetById(customerId);

            return result;
        });

        app.MapPost("api/bookstore/create", async (
            [FromBody] BookStores body,
            [FromServices] IBookStoreService services) =>
        {
            await services.Create(body);
        });

        app.MapPut("api/bookstore/update", async (
           [FromBody] BookStores body,
           [FromServices] IBookStoreService services) =>
        {
            await services.Update(body);
        });

        app.MapGet("api/bookstore/all", async (
            [FromServices] IBookStoreService services) =>
        {
            var result = await services.GetAll();

            return result;
        });
    }
}