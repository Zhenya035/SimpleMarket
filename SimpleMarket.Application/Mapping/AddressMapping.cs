using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public static class AddressMapping
{
    public static GetAddressDto GetMapToDto(Address addressRequest) => 
        new GetAddressDto
        {
            Id = addressRequest.Id,
            Country = addressRequest.Country,
            City = addressRequest.City,
            Street = addressRequest.Street,
            HomeNumber = addressRequest.HomeNumber,
            PostalCode = addressRequest.PostalCode,
        };
    
    public static Address AddMapFromDto(AddAddressDto addressRequest, long userId) =>
        new Address()
        {
            Country = addressRequest.Country,
            City = addressRequest.City,
            Street = addressRequest.Street,
            HomeNumber = addressRequest.HomeNumber,
            PostalCode = addressRequest.PostalCode,
            UserId = userId
        };
}