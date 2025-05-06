using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.Response;

public class GetCartDto
{
    public long Id { get; init; }
    
    public List<string> Products { get; set; } = [];

    public decimal TotalPrice { get; set; } = 0;
}