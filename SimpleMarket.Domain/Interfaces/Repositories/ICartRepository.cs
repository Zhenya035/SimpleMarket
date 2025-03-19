using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICartRepository
{
    public Task<Cart> GetCartByUser(long userId);
    public Task CreateCart(Cart cart);
    public Task DeleteCart(long id);
    public Task<List<Product>> GetAllProductsInCart(long cartId);
    public Task AddProductToCart(long cartId, long productId);
    public Task DeleteProductInCart(long cartId, long productId);
    public Task DeleteProductsInCart(long cartId);
}