using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.GetUser;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public static class AddressMapping
{
    public static GetUserAddressDTO MapFromDto(Address addressRequest)
    {
        return new GetUserAddressDTO
        {
            Country = addressRequest.Country,
            City = addressRequest.City,
            Street = addressRequest.Street,
            PostalCode = addressRequest.PostalCode,
        };
    }
}