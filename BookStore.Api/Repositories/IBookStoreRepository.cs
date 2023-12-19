namespace BookStore.Api.Repositories;

public interface IBookStoreRepository
{
    Task<List<BookStoresDTO>> GetAll();
    Task<BookStoresDTO> GetById(Guid id);
    Task Create(BookStoresDTO dto);
    Task Update(BookStoresDTO dto);
}