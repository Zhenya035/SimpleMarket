using SimpleMarket.Application.DTOs;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class AddressMapping
{
    public static AddressRequest MapFromDto(Address addressRequest)
    {
        return new AddressRequest
        {
            Country = addressRequest.Country,
            City = addressRequest.City,
            Street = addressRequest.Street,
            PostalCode = addressRequest.PostalCode,
        };
    }
}