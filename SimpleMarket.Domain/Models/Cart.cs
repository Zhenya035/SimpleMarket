namespace SimpleMarket.Core.Models;

public class Cart
{
    public long Id { get; init; }
    
    public List<Product> Products { get; set; } = [];

    public decimal TotalPrice { get; set; } = 0;
    
    public long UserId { get; init; }
    public User User { get; init; }
}