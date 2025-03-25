using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class CartService(ICartRepository cartRepository)
{
    public async Task<Cart> GetCartByUser(long userId)
    {
        try
        {
            var cart = await cartRepository.GetCartByUser(userId);
            return cart;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task CreateCart(long userId)
    {
        var cart = new Cart()
        {
            UserId = userId
        };

        try
        {
            await cartRepository.CreateCart(cart);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task DeleteCart(long id)
    {
        try
        {
            await cartRepository.DeleteCart(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<Product>> GetCartProducts(long cartId)
    {
        try
        {
            var products = await cartRepository.GetAllProductsInCart(cartId);
            return products;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task AddProduct(long cartId, long productId)
    {
        try
        {
            await cartRepository.AddProductToCart(cartId, productId);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task RemoveProduct(long cartId, long productId)
    {
        try
        {
            await cartRepository.DeleteProductInCart(cartId, productId);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task RemoveAllProducts(long cartId)
    {
        try
        {
            await cartRepository.DeleteProductsInCart(cartId);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}