using SimpleMarket.Persistance.Enams;

namespace SimpleMarket.Persistance.Entities;

public class User
{
    public long Id { get; set; }
    
    public Role Role { get; set; } = Role.User;
    public string Username { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Product> FavouriteProducts { get; set; } = new List<Product>();
    
    public List<Card> Cards { get; set; } = new List<Card>();
    
    public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    
    public List<Address> Addresses { get; set; } = new List<Address>();
    
    public long HistoryId { get; set; }
    public History History { get; set; } = new History();
    
    public long CartId { get; set; }
    public Cart Cart { get; set; } = new Cart();
}