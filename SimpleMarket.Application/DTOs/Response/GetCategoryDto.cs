namespace SimpleMarket.Application.DTOs.Response;

public class GetCategoryDto
{
    public long Id { get; init; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public List<GetProductDto> Products { get; set; } = [];
}