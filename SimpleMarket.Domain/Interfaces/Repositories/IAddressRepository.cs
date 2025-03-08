using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IAddressRepository
{
    public Task<List<Address>> GetAllAddressesByUser(long userId);
    public Task<List<Address>> GetAllAddressesById(long addressId);
    public Task AddAddress(Address address, long userId);
    public Task UpdateAddress(Address address, long addressId);
    public Task DeleteAddress(long id);
}