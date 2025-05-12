namespace SimpleMarket.Application.DTOs.Response;

public class GetProductDto
{
    public long Id { get; init; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public decimal Price { get; set; } = decimal.Zero;
    
    public List<string> Images { get; set; } = [];
    
    public string CategoryName { get; set; } = string.Empty;
    
    public double Evaluation { get; set; } = 0;
}