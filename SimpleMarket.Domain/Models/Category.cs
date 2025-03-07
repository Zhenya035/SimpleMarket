namespace SimpleMarket.Core.Models;

public class Category
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public List<Product> Products { get; set; } = new List<Product>();
}