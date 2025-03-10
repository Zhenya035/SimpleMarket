namespace SimpleMarket.Application.DTOs.Response;

public class GetFeedbackDto
{
    public long Id { get; init; }
    
    public string Text { get; set; } = string.Empty;
    
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    
    public double Evaluation { get; set; } = 0;
    
    public string UserName { get; set; } = string.Empty;
    
    public string ProductName { get; set; } = string.Empty;
}