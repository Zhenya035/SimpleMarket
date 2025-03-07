namespace SimpleMarket.Core.Models;

public class Feedback
{
    public long Id { get; set; }
    
    public string Text { get; set; } = string.Empty;
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public double Evaluation { get; set; } = 0.0;
    
    public long UserId { get; set; }
    public User User { get; set; } = new User();
    
    public long ProductId { get; set; }
    public Product Product { get; set; } = new Product();
}