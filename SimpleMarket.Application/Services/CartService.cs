using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class CartService(ICartRepository cartRepository)
{
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
}