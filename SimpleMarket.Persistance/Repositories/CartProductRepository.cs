using Microsoft.EntityFrameworkCore;

namespace SimpleMarket.Persistance.Repositories;

public class CartProductRepository(SimpleMarketDbContext dbContext) : ICartProductRepository
{
    public async Task DeleteCartProduct(long CartId)
    {
        var cartProducts = await dbContext.CartProducts
            .Where(c => c.CartId == CartId)
            .ToListAsync();
        
        dbContext.CartProducts.RemoveRange(cartProducts);
        await dbContext.SaveChangesAsync();
    }
}