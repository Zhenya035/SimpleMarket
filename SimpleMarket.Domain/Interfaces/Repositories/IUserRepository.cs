using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUserById(long id);
    public Task<long> Login(string username, string password);
    public Task AddFavouriteProduct(long userId, long productId);
    public Task<List<Product>> GetFavouriteProducts(long userId);
    public Task<long> AddUser(User user);
    public Task UpdateUser(User user, long userId);
    public Task DeleteUser(long id);
}