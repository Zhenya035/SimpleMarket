using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICartRepository
{
    public Task<Cart> GetAllCartsByUser(long userId);
    public Task CreateCart(Cart cart);
    public Task UpdateCart(Cart cart);
    public Task DeleteCart(long id);
}