namespace SimpleMarket.Application.DTOs.Response;

public class GetProductDto
{
    public long Id { get; init; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public decimal Price { get; set; } = decimal.Zero;
    
    public List<string> Images { get; set; } = [];
    
    public GetCategoryDto Category { get; set; } = new GetCategoryDto();
    
    public List<GetFeedbackDto> Feedbacks { get; set; } = [];
    
    public List<GetHistoryDto> History { get; set; } = [];
    
    public List<GetCartDto> Carts { get; set; } = [];
}