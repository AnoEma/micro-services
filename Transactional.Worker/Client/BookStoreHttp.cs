using Flurl.Http;
using Transactional.Worker.BookStore;

namespace Transactional.Worker.Client;

public class BookStoreHttp : IBookStoreHttp
{
    private readonly ILogger<BookStoreHttp> _logger;

    public BookStoreHttp(ILogger<BookStoreHttp> logger)
    {
        _logger = logger;
    }

    public async Task CreateBookstore(BookStoreEvent dto, CancellationToken cancellation)
    {
        try
        {
            if (dto is not BookStoreEvent)
            {
                _logger.LogInformation("Seu filho da mãe bagulho não tá boa não kkkkkkkkkkk");
                throw new Exception();
            }

            var result = await "http://localhost:5164/api/bookstore/create".PostJsonAsync(dto, HttpCompletionOption.ResponseContentRead, cancellation);
        }
        catch (Exception)
        {
            throw;
        }
    }
}