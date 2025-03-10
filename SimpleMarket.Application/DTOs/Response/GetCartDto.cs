using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.GetUser;

public class GetCartDto
{
    public long Id { get; init; }
    
    public List<Product> Products { get; set; } = [];

    public decimal TotalPrice { get; set; } = 0;
}