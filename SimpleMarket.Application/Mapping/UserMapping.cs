using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public static class UserMapping
{
    public static GetUserDto MapToResponseDto(User user) => 
        new GetUserDto
        {
            Id = user.Id,
            Role = user.Role,
            Username = user.Username,
            Sex = user.Sex,
            Password = user.Password,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FavouriteProducts = user.FavouriteProducts.Select(fP => fP.Name).ToList(),
            Feedbacks = user.Feedbacks.Select(f => f.Text).ToList(),
            Addresses = user.Addresses.Select(a => a.ToString()).ToList(),
            Cart = user.Cart.Products.Select(c => c.Product.Name).ToList(),
            History = user.History.Products.Select(h => h.Product.Name).ToList(),
        };
    
    public static User MapFromRequestDto(AddUserDto user) =>
        new User
        {
            Role = user.Role,
            Username = user.Username,
            Sex = user.Sex,
            Password = user.Password,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
}