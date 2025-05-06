using SimpleMarket.Persistance.Repositories;

namespace SimpleMarket.Application.Services;

public class CartProductService(ICartProductRepository cartProductRepository)
{
    public async Task DeleteProductsInCart(long cartId)
    {
        await cartProductRepository.DeleteCartProduct(cartId);
    }
}