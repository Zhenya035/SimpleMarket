using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class UserService(IUserRepository userRepository, IProductRepository productRepository)
{
    public async Task<List<User>> GetAllUsers()
    {
        var users = await userRepository.GetAllUsers();

        if (users == null)
            throw new KeyNotFoundException("Users not found");

        return users;
    }

    public async Task<User> GetUserById(long id)
    {
        var user = await userRepository.GetUserById(id);
        
        if(user == null)
            throw new KeyNotFoundException("User not found.");
        
        return user;
    }

    public async Task AddUser(User user)
    {
        try
        {
            await userRepository.AddUser(user);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    public async Task UpdateUser(User user, long userId)
    {
        var foundUser = await userRepository.GetUserById(userId);
        
        if (foundUser == null)
            throw new KeyNotFoundException("User not found.");
        
        try
        {
            await userRepository.UpdateUser(user, userId);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    public async Task DeleteUser(long userId)
    {
        var user = await userRepository.GetUserById(userId);
        
        if(user == null)
            throw new KeyNotFoundException("User not found.");
        
        await userRepository.DeleteUser(userId);
    }
}