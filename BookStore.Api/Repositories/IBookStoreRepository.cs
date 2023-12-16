namespace BookStore.Api.Repositories;

public interface IBookStoreRepository
{
    Task GetAll();
    Task GetById(Guid id);
    Task Create(BookStoresDTO dto);
    Task Update(BookStoresDTO dto);
}