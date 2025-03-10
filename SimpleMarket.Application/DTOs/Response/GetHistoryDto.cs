using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.Response;

public class GetHistoryDto
{
    public long Id { get; init; }
    
    public List<GetProductDto> Products { get; set; } = [];
    
    public string UserName { get; init; } = string.Empty;
}