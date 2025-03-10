namespace SimpleMarket.Application.DTOs;

public class GetUserAddressDTO
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
}