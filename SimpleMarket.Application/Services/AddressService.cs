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

    public async Task<List<GetAddressDto>> GetAddressesById(long id)
    {
        var addresses = await addressRepository.GetAllAddressesById(id);
        
        if (addresses.Count == 0)
            throw new KeyNotFoundException("Addresses not found");
        
        return addresses.Select(a => AddressMapping.GetMapToDto(a)).ToList();
    }

    public async Task AddAddress(AddAddressDto newAddress, long userId)
    {
        var address = AddressMapping.AddMapFromDto(newAddress, userId);
        
        await addressRepository.AddAddress(address, userId);
    }

    public async Task UpdateAddress(AddAddressDto newAddress, long addressId, long userId)
    {
        var addresses = await addressRepository.GetAllAddressesById(addressId);
        
        if (addresses.Count == 0)
            throw new KeyNotFoundException("Address not found");
        
        var address = AddressMapping.AddMapFromDto(newAddress, userId);
        
        try
        {
            await addressRepository.UpdateAddress(address, addressId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteAddress(long addressId, long userId)
    {
        var addresses = await addressRepository.GetAllAddressesById(userId);
        
        if(addresses.Count == 0)
            throw new KeyNotFoundException("User don't have addresses.");

        try
        {
            await addressRepository.DeleteAddress(addressId);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}