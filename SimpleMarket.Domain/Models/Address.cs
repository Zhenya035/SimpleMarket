namespace SimpleMarket.Core.Models;

public class Address
{
    public long Id { get; set; }
    
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    
    public long UserId { get; set; }
    public User User { get; set; } = new User();
}