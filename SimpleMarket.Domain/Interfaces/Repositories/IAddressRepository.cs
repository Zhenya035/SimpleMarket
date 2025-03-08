using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IAddressRepository
{
    public Task<List<Address>> GetAllAddressesByUser(long userId);
    public Task AddAddress(Address address, long userId);
    public Task UpdateAddress(Address address);
    public Task DeleteAddress(long id);
}