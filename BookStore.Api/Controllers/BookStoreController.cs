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

    [HttpGet("/all")]
    public async Task<ActionResult<List<BookStores>>> GetAllBookStore()
    {
        return await _service.GetAll();
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<BookStores>> GetBookStore(Guid id)
    {
        return await _service.GetById(id);
    }

    [HttpPost("/create")]
    public async Task<ActionResult> Create([FromBody] BookStores model)
    {
         await _service.Create(model);

        return Created();
    }

    [HttpPost("/update")]
    public async Task<ActionResult> Update([FromBody] BookStores model)
    {
        await _service.Update(model);

        return Accepted();
    }
}