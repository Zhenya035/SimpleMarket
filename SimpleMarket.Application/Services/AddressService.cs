using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class AddressService(IAddressRepository addressRepository)
{
    public async Task<List<Address>> GetAddressesByUser(long userId)
    {
        var addresses = await addressRepository.GetAllAddressesByUser(userId);
        
        if (addresses == null)
            throw new KeyNotFoundException("Addresses not found");
        
        return addresses;
    }

    public async Task AddAddress(Address address, long userId)
    {
        try
        {
            await addressRepository.AddAddress(address, userId);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task UpdateAddress(Address address, long addressId)
    {
        var addresses = await addressRepository.GetAllAddressesById(addressId);
        
        if (addresses == null)
            throw new KeyNotFoundException("Address not found");
        
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
        
        if(addresses == null)
            throw new KeyNotFoundException("Address not found.");
        
        await addressRepository.DeleteAddress(addressId);
    }
}