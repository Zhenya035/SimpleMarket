using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class AddressRepository : IAddressRepository
{
    public Task<List<Address>> GetAllAddressesByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddAddress(Address address)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAddress(Address address)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAddress(long id)
    {
        throw new NotImplementedException();
    }
}