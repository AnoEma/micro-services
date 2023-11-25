using Customer.Api.Model;
using Customer.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    public async Task<ActionResult<Customers>> GetCustomer()
    {
       return await _service.GetCustomersAsync();
    }
}