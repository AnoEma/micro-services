using BookStore.Api.Model;
using BookStore.Api.Repositories;

namespace BookStore.Api.Services;

public class BookStoreService : IBookStoreService
{
    private readonly IBookStoreRepository _repository;
    private readonly ILogger<BookStoreService> _logger;

    public BookStoreService(IBookStoreRepository repository, ILogger<BookStoreService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task Create(BookStores entity)
    {
       await _repository.Create(entity);
    }

    public async Task<List<BookStores>> GetAll()
    {
        var result = new List<BookStores>();
        
        var getBookstores = await  _repository.GetAll();
        if(!getBookstores.Any())
        {
            _logger.LogInformation("Don't have bookstore");
            return result;
        }
        return result;
    }

    public async Task<BookStores> GetById(Guid id)
    {
        var getBookstore = await _repository.GetById(id);
        if(getBookstore is null)
        {
            _logger.LogInformation("Don't have registre");
            return null;
        }
        return getBookstore;
    }

    public async Task Update(BookStores entity)
    {
        var getBookstore = await _repository.GetById(entity.Id);
        if (getBookstore is null)
        {
            _logger.LogInformation("Don't have registre");
            return;
        }
        await _repository.Update(entity);
    }
}