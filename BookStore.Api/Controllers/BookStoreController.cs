using BookStore.Api.Model;
using BookStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookStoreController : ControllerBase
{
    private readonly IBookStoreService _service;

    public BookStoreController(IBookStoreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookStores>>> GetAllBookStore()
    {
        return await _service.GetAll();
    }
}