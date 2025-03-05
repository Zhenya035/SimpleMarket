namespace SimpleMarket.Persistance.Entities;

public class FeedbackEntity
{
    public long Id { get; set; }
    
    public string Text { get; set; } = string.Empty;
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public double Evaluation { get; set; } = 0.0;
    
    public long UserId { get; set; }
    public UserEntity User { get; set; } = new UserEntity();
    
    public long ProductId { get; set; }
    public ProductEntity Product { get; set; } = new ProductEntity();
}