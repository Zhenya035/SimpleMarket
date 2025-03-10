namespace SimpleMarket.Application.DTOs.Response;

public class GetAddressDto
{
    public long Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
}