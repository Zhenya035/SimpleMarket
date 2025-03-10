using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CartRepository(SimpleMarketDbContext dbContext) : ICartRepository
{
    public Task<Cart> GetAllCartsByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateCart(Cart cart)
    {
        if (cart == null)
            throw new ArgumentNullException(nameof(cart), "User cannot be null");

        try
        {
            await dbContext.Carts.AddAsync(cart);
            await dbContext.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception("Error creating cart", e);
        } 
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