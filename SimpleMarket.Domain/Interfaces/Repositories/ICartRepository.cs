using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICartRepository
{
    public Task CreateCart(Cart cart);
    public Task<Cart> GetAllProductsByUser(long userId);
    public Task AddProductToCart(long userId, long productId);
    public Task DeleteProductInCart(long cartId, long productId);
}