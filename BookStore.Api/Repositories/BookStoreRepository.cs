using BookStore.Api.Data;
using BookStore.Api.Model;

namespace BookStore.Api.Repositories;

public class BookStoreRepository : IBookStoreRepository
{
    private readonly BookStoreContext _context;

    public BookStoreRepository(BookStoreContext context)
    {
        _context = context;
    }

    public async Task Create(BookStores dto)
    {
        dto.DateCreate = DateTime.Now;

        await _context.BookStores.AddAsync(dto);
        await _context.SaveChangesAsync();
    }

    public Task<List<BookStores>> GetAll()
    {
        var result = _context.BookStores.ToList();

        return Task.FromResult(result);
    }

    public Task<BookStores> GetById(Guid id)
    {
        var result = _context.BookStores.FirstOrDefault(x => x.Id == id);

        return Task.FromResult(result);
    }

    public async Task Update(BookStores dto)
    {
        var bookstore = _context.BookStores.FirstOrDefault(x => x.Id == dto.Id);
        if (bookstore is not null)
        {
            dto.DateUpdated = DateTime.Now.ToString();
            _context.BookStores.Update(dto);
            await _context.SaveChangesAsync();
        }
    }
}