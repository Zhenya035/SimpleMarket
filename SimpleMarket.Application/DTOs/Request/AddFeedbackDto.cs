namespace SimpleMarket.Application.DTOs.Request;

public class AddFeedbackDto
{
    public string Text { get; set; } = string.Empty;
    
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    
    public double Evaluation { get; set; } = 0;
}