namespace SimpleMarket.Core.Models;

public class Cart
{
    public long Id { get; set; }
    
    public List<Product> Products { get; set; } = new List<Product>();
    
    public long UserId { get; set; }
    public User User { get; set; } = new User();
}