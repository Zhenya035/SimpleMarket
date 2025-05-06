using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICartRepository
{
    public Task CreateCart(Cart cart);
    public Task<Cart> GetAllProductsInCart(long cartId);
    public Task AddProductToCart(long cartId, long productId);
    public Task DeleteProductInCart(long cartId, long productId);
}