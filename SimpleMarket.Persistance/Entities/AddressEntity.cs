namespace SimpleMarket.Persistance.Entities;

public class AddressEntity
{
    public long Id { get; set; }
    
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    
    public long UserID { get; set; }
    public UserEntity User { get; set; } = new UserEntity();
}