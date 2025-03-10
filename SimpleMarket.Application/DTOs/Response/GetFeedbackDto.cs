namespace SimpleMarket.Application.DTOs.GetUser;

public class GetFeedbackDto
{
    public long Id { get; init; }
    
    public string Text { get; set; } = string.Empty;
    
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    
    public double Evaluation { get; set; } = 0;
    
    public long UserId { get; init; }
    
    public long ProductId { get; init; }
}