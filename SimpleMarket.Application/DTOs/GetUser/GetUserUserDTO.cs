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
    
    public List<GetUserFeedbackDTO> Feedbacks { get; init; } = [];
    
    public IEnumerable<GetUserAddressDTO> Addresses { get; init; } = [];
    
    public GetUserHistoryDTO History { get; init; }
    
    public GetUserCartDTO Cart { get; init; }
}