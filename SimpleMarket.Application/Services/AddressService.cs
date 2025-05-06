using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;

namespace SimpleMarket.Application.Services;

public class AddressService(IAddressRepository addressRepository)
{
    public async Task<List<GetAddressDto>> GetAddressesByUser(long userId)
    {
        var addresses = await addressRepository.GetAllAddressesByUser(userId);
        
        if (addresses.Count == 0)
            throw new KeyNotFoundException("Addresses is empty");
        
        return addresses.Select(a => AddressMapping.GetMapToDto(a)).ToList();
    }

    public async Task<GetAddressDto> GetAddressesById(long id)
    {
        var address = await addressRepository.GetAddressById(id);
        
        if (address == null)
            throw new KeyNotFoundException("Address not found");
        
        return AddressMapping.GetMapToDto(address);
    }

    public async Task AddAddress(AddAddressDto newAddress, long userId)
    {
        var address = AddressMapping.AddMapFromDto(newAddress, userId);
        
        await addressRepository.AddAddress(address, userId);
    }

    public async Task UpdateAddress(AddAddressDto newAddress, long addressId)
    {
        var address = await addressRepository.GetAddressById(addressId);
        
        if (address == null)
            throw new KeyNotFoundException("Address not found");
        
        address = AddressMapping.AddMapFromDto(newAddress, address.UserId);
        
        await addressRepository.UpdateAddress(address, addressId);
    }

    public async Task DeleteAddress(long addressId)
    {
        await addressRepository.DeleteAddress(addressId);
   }
}