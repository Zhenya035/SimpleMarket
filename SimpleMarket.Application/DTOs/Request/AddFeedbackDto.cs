namespace SimpleMarket.Application.DTOs.Request;

public class AddFeedbackDto
{
    public string Text { get; set; } = string.Empty;
    
    public double Evaluation { get; set; } = 0;
}