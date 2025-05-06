using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class CartService(ICartRepository cartRepository, CartProductService cartProductService)
{
    public async Task CreateCart(long userId)
    {
        var cart = new Cart()
        {
            UserId = userId
        };
        await cartRepository.CreateCart(cart);
    }

    public async Task<List<GetProductDto>> GetCartProducts(long cartId)
    {
        var cart = await cartRepository.GetAllProductsInCart(cartId);
        var products = cart.Products.Select(cp => cp.Product).ToList();
        
        return products.Select(ProductMapping.MapToGetProductDto).ToList();
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
        await cartProductService.DeleteProductsInCart(cartId);
    }
}