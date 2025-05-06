namespace SimpleMarket.Core.Models;

public class Address
{
    public long Id { get; init; }
    
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    
    public long UserId { get; init; }
    public User User { get; init; }

    public override string ToString()
    {
        return Country + ", " + City + ", " + Street + ", " + HomeNumber + ", " + PostalCode;
    }
}