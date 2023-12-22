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
            [FromServices] ICustomerService services) =>
        {
            await services.CreateCustomer(body, default);
        });

        app.MapPut("api/customer/update", async (
           [FromBody] Customers body,
           [FromServices] ICustomerService services) =>
        {
            await services.UpdateCustomer(body, default);
        });

        app.MapDelete("api/customer/delete/{id}", async (
           [FromRoute] string id,
           [FromServices] ICustomerService services) =>
        {
            var customerId = new Guid(id);
            await services.DeleteCustomer(customerId, default);
        });

        app.MapGet("api/customer/all", async (
            [FromServices] ICustomerService services) =>
        {
            var result = await services.GetCustomers(default);

            return result;
        });
    }
}