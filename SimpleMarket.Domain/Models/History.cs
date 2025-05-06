namespace SimpleMarket.Core.Models;

public class History
{
    public long Id { get; init; }
    
    public List<HistoryProduct> Products { get; set; } = [];
    
    public long UserId { get; init; }
    public User User { get; init; }
}