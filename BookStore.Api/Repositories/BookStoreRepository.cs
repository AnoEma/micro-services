using BookStore.Api.Data;

namespace BookStore.Api.Repositories;

public class BookStoreRepository : IBookStoreRepository
{
    private readonly BookStoreContext _context;

    public BookStoreRepository(BookStoreContext context)
    {
        _context = context;
    }

    public async Task Create(BookStoresDTO dto)
    {
        await _context.BookStores.AddAsync(dto);
        await _context.SaveChangesAsync();
    }

    public Task GetAll()
    {
        var bookstore = _context.BookStores.ToList();
        if (bookstore.Any())
        {
            return Task.FromResult(bookstore);
        }
        return Task.CompletedTask;
    }

    public Task GetById(Guid id)
    {
        var bookstore = _context.BookStores.FirstOrDefault(x => x.Id == id);
        if (bookstore is not null)
        {
            return Task.FromResult(result: bookstore);
        }
        return Task.CompletedTask;
    }

    public async Task Update(BookStoresDTO dto)
    {
        var bookstore = _context.BookStores.FirstOrDefault(x => x.Id == dto.Id);
        if (bookstore is not null)
        {
            dto.DateUpdated = DateTime.Now.ToString();
            _context.BookStores.Update(dto);
        }
    }
}