using SimpleMarket.Core.Enums;

namespace SimpleMarket.Core.Models;

public class User
{
    public long Id { get; set; }
    
    public Role Role { get; set; } = Role.User;
    public string Username { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Product>? FavouriteProducts { get; set; } = [];
    
    public List<Card>? Cards { get; set; } = [];
    
    public List<Feedback>? Feedbacks { get; set; } = [];
    
    public List<Address>? Addresses { get; set; } = [];
    
    public History? History { get; set; }
    
    public Cart? Cart { get; set; }
}