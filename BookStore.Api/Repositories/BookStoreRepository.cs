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
        dto.DateCreated = new DateTimeOffset();

        await _context.BookStores.AddAsync(dto);
        await _context.SaveChangesAsync();
    }

    public Task<List<BookStoresDTO>> GetAll()
    {
        var result = _context.BookStores.ToList();

        return Task.FromResult(result);
    }

    public Task<BookStoresDTO> GetById(Guid id)
    {
        var result = _context.BookStores.FirstOrDefault(x => x.Id == id);

        return Task.FromResult(result);
    }

    public async Task Update(BookStoresDTO dto)
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