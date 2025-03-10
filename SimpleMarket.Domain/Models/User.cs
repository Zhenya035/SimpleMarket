using System.ComponentModel.DataAnnotations;
using SimpleMarket.Core.Enums;

namespace SimpleMarket.Core.Models;

public class User
{
    public long Id { get; init; }
    
    public Role Role { get; set; } = Role.User;
    public string Username { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Product> FavouriteProducts { get; set; } = [];
    
    public List<Feedback> Feedbacks { get; init; } = [];
    
    public List<Address> Addresses { get; init; } = [];
    
    public History History { get; init; }
    
    public Cart Cart { get; init; }
}