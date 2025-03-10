using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.GetUser;

public class GetHistoryDto
{
    public long Id { get; init; }
    
    public List<Product> Products { get; set; } = [];
}