namespace SimpleMarket.Application.DTOs.Request;

public class AddProductDto
{
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public decimal Price { get; set; } = decimal.Zero;
    
    public List<string> Images { get; set; } = [];
    
    public long CategoryId { get; set; }
}