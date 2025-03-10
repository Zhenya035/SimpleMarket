using SimpleMarket.Core.Enums;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.GetUser;

public class GetUserDTO
{
    public long Id { get; init; }
    
    public Role Role { get; set; } = Role.User;
    
    public string Username { get; set; } = string.Empty;
    
    public string Sex { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public List<Product> FavouriteProducts { get; set; } = [];
    
    public List<GetFeedbackDto> Feedbacks { get; init; } = [];
    
    public IEnumerable<GetAddressDto> Addresses { get; init; } = [];
    
    public GetHistoryDto History { get; init; }
    
    public GetCartDto Cart { get; init; }
}