using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.DTOs.GetUser;

public class GetUserHistoryDTO
{
    public long Id { get; init; }
    
    public List<Product> Products { get; set; } = [];
    
    public long UserId { get; init; }
}