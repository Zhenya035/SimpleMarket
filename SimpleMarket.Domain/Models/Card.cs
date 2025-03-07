namespace SimpleMarket.Persistance.Entities;

public class Card
{
    public long Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public DateOnly ExpiryDate { get; set; } = new DateOnly();
    public string CvvCode { get; set; } = string.Empty;
    
    public long UserId { get; set; }
    public User User { get; set; } = new User();
}