namespace SimpleMarket.Core.Models;

public class HistoryProduct
{
    public long Id { get; set; }

    public long HistoryId { get; set; }
    public History History { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}