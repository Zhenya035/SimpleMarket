using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.GetUser;

public class GetUserCartDTO
{
    public long Id { get; init; }
    
    public List<Product> Products { get; set; } = [];

    public decimal TotalPrice { get; set; } = 0;
    
    public long UserId { get; init; }
}