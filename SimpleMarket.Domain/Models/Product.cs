namespace SimpleMarket.Core.Models;

public class Product
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public List<string> Images { get; set; } = new List<string>();
    
    public long CategoryId { get; set; }
    public Category Category { get; set; } = new Category();
    
    public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    
    public List<History> Histories { get; set; } = new List<History>();
    
    public List<Cart> Carts { get; set; } = new List<Cart>();
    
}