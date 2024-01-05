using CustomerService.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Endpoint;

public static class CustomerEndpoint
{
    public static void AddEndpoints(WebApplication app)
    {
        app.MapGet("api/customer/heath", () =>
        {
            return "ok";
        });

        app.MapGet("api/customer/{id}", async (
            [FromRoute] string id,
            [FromServices] ICustomerService services) =>
        {
            var customerId = new Guid(id);
            var result = await services.GetCustomerById(customerId, default);

            return result;
        });

        app.MapPost("api/customer/create", async (
            [FromBody] Customers body,
            [FromServices] ICustomerService services,
            CancellationToken cancellationToken) =>
        {
            await services.CreateCustomer(body, cancellationToken);
        });

        app.MapPut("api/customer/update", async (
           [FromBody] Customers body,
           [FromServices] ICustomerService services,
           CancellationToken cancellationToken) =>
        {
            await services.UpdateCustomer(body, cancellationToken);
        });

        app.MapDelete("api/customer/delete/{id}", async (
           [FromRoute] string id,
           [FromServices] ICustomerService services,
           CancellationToken cancellationToken) =>
        {
            var customerId = new Guid(id);
            await services.DeleteCustomer(customerId, cancellationToken);
        });

        app.MapGet("api/customer/all", async (
            [FromServices] ICustomerService services,
            CancellationToken cancellationToken) =>
        {
            var result = await services.GetCustomers(cancellationToken);

            return result;
        });
    }
}