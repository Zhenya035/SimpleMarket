using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class CartService(ICartRepository cartRepository)
{
    public async Task<GetCartDto> GetCartByUser(long userId)
    {
        var cart = await cartRepository.GetCartByUser(userId);
        return CartMapping.MapToGetCartDto(cart);
    }
    
    public async Task CreateCart(long userId)
    {
        var cart = new Cart()
        {
            UserId = userId
        };
        await cartRepository.CreateCart(cart);
    }

    public async Task DeleteCart(long id)
    {
        await cartRepository.DeleteCart(id);
    }

    public async Task<List<GetProductDto>> GetCartProducts(long cartId)
    {
        var products = await cartRepository.GetAllProductsInCart(cartId);
        return products.Select(p => ProductMapping.MapToGetProductDto(p)).ToList();
    }

    public async Task AddProduct(long cartId, long productId)
    {
        await cartRepository.AddProductToCart(cartId, productId);
    }

    public async Task RemoveProduct(long cartId, long productId)
    {
        await cartRepository.DeleteProductInCart(cartId, productId);
    }

    public async Task RemoveAllProducts(long cartId)
    {
        await cartRepository.DeleteProductsInCart(cartId);
    }
}