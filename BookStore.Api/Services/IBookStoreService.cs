using BookStore.Api.Model;

namespace BookStore.Api.Services;

public interface IBookStoreService
{
   public Task<List<BookStores>> GetAll();
}