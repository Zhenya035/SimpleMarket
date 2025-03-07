using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUserById(long id);
    public Task AddFavouriteProduct(long userId, long productId);
    public Task AddUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(long id);
}