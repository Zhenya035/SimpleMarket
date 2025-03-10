using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.Response;

public class GetCartDto
{
    public long Id { get; init; }
    
    public List<GetProductDto> Products { get; set; } = [];

    public decimal TotalPrice { get; set; } = 0;
}