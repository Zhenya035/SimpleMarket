using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CartRepository : ICartRepository
{
    public Task<Cart> GetAllCartsByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task CreateCart(Cart cart)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCart(Cart cart)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCart(long id)
    {
        throw new NotImplementedException();
    }
}