using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.GetUser;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class UserMapping
{
    public static GetUserDTO MapToDto(User user)
    {
        return new GetUserDTO
        {
            Id = user.Id,
            Role = user.Role,
            Username = user.Username,
            Sex = user.Sex,
            Password = user.Password,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FavouriteProducts = user.FavouriteProducts,
            Feedbacks = new List<GetFeedbackDto>(),
            Addresses = user.Addresses.Select(a => AddressMapping.MapFromDto(a)).ToList(),
            
            Cart = new GetCartDto
            {
                Id = user.Cart.Id,
            },
            History = new GetHistoryDto()
            {
                Id = user.History.Id,
            }
        };
    }
}