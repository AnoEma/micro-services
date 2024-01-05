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

    public async Task Create(BookStores entity, CancellationToken cancellation)
    {
       await _repository.Create(entity, cancellation);
    }

    public async Task<List<BookStores>> GetAll(CancellationToken cancellation)
    {
        var result = new List<BookStores>();
        
        var getBookstores = await  _repository.GetAll(cancellation);
        if(!getBookstores.Any())
        {
            _logger.LogInformation("Don't have bookstore");
            return result;
        }
        return result;
    }

    public async Task<BookStores> GetById(Guid id, CancellationToken cancellation)
    {
        var getBookstore = await _repository.GetById(id, cancellation);
        if(getBookstore is null)
        {
            _logger.LogInformation("Don't have registre");
            return null;
        }
        return getBookstore;
    }

    public async Task Update(BookStores entity, CancellationToken cancellation)
    {
        var getBookstore = await _repository.GetById(entity.Id, cancellation);
        if (getBookstore is null)
        {
            _logger.LogInformation("Don't have registre");
            return;
        }
        await _repository.Update(entity, cancellation);
    }
}