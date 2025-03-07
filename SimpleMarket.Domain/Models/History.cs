namespace SimpleMarket.Persistance.Entities;

public class History
{
    public long Id { get; set; }
    
    public List<Product> Products { get; set; } = new List<Product>();
    
    public long UserId { get; set; }
    public User User { get; set; } = new User();
}