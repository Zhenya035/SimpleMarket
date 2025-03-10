using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class UserService(IUserRepository userRepository, CartService cartService, HistoryService historyService)
{
    public async Task<List<GetUserDto>> GetAllUsers()
    {
        var users = await userRepository.GetAllUsers();

        if (users == null)
            throw new KeyNotFoundException("Users not found");
        
        return users.Select(u => UserMapping.MapToResponseDto(u)).ToList();
    }

    public async Task<GetUserDto> GetUserById(long id)
    {
        var user = await userRepository.GetUserById(id);
        
        if(user == null)
            throw new KeyNotFoundException("User not found.");
        
        return UserMapping.MapToResponseDto(user);
    }

    public async Task AddFavouriteProduct(long userId, long productId)
    {
        try
        {
            await userRepository.AddFavouriteProduct(userId, productId);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task AddUser(AddUserDto newUser)
    {
        var user = UserMapping.MapFromRequestDto(newUser);
        
        try
        {
            var userId = await userRepository.AddUser(user);

            await cartService.CreateCart(userId);
            await historyService.CreateHistory(userId);
            
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    public async Task UpdateUser(AddUserDto newUser, long userId)
    {
        var foundUser = await userRepository.GetUserById(userId);
        
        if (foundUser == null)
            throw new KeyNotFoundException("User not found.");
        
        var user = UserMapping.MapFromRequestDto(newUser);
        
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