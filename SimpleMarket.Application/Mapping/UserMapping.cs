using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class UserMapping
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
            FavouriteProducts = user.FavouriteProducts.Select(fP => ProductMapping.MapToGetProductDto(fP)).ToList(),
            Feedbacks = user.Feedbacks.Select(f => FeedbackMapping.MapToGetFeedbackDto(f)).ToList(),
            Addresses = user.Addresses.Select(a => AddressMapping.MapFromDto(a)).ToList(),
            Cart = CartMapping.MapToGetCartDto(user.Cart),
            History = HistoryMapping.MapToGetHistoryDto(user.History),
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