using CustomerService.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Endpoint;

public static class CustomerEndpoint
{
    public static void AddEndpoints(WebApplication app)
    {
        app.MapGet("heath", () =>
        {
            return "ok";
        });

        app.MapGet("api/customer{id}", async (
            [FromRoute] string id,
            [FromServices] ICustomerService services) =>
        {
            var customerId = new Guid(id);
            var result = await services.GetCustomerById(customerId, default);

            return result;
        });

        app.MapPost("api/create", async (
            [FromBody] Customers body,
            [FromServices] ICustomerService services) =>
        {
            await services.CreateCustomer(body, default);
        });

        app.MapPost("api/update", async (
           [FromBody] Customers body,
           [FromServices] ICustomerService services) =>
        {
            await services.UpdateCustomer(body, default);
        });

        app.MapPost("api/delete/{id}", async (
           [FromRoute] string id,
           [FromServices] ICustomerService services) =>
        {
            var customerId = new Guid(id);
            await services.DeleteCustomer(customerId, default);
        });

        app.MapGet("api/customers", async (
            [FromServices] ICustomerService services) =>
        {
            var result = await services.GetCustomers(default);

            return result;
        });
    }
}