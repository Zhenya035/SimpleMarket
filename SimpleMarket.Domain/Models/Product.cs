namespace SimpleMarket.Core.Models;

public class Product
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public List<string> Images { get; set; } = [];
    
    public long CategoryId { get; set; }
    public Category Category { get; set; } = new Category();
    
    public List<Feedback> Feedbacks { get; set; } = [];
    
    public List<History> Histories { get; set; } = [];
    
    public List<Cart> Carts { get; set; } = [];
    
}