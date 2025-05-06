using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CartRepository(SimpleMarketDbContext dbContext) : ICartRepository
{
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

    public async Task<Cart> GetAllProductsInCart(long cartId)
    {
        var cart = await dbContext.Carts
            .AsNoTracking()
                .Include(c => c.Products)
                    .ThenInclude(p => p.Product)
                        .ThenInclude(p => p.Category)
                .Include(c => c.Products)
                    .ThenInclude(p => p.Product)
                        .ThenInclude(p => p.Feedbacks)
                .FirstOrDefaultAsync(c => c.Id == cartId);

        if (cart == null)
            throw new KeyNotFoundException("Cart not found");
        
        return cart;
    }

    public async Task AddProductToCart(long cartId, long productId)
    {
        var cart = await dbContext.Carts
            .Include(p => p.Products)
                .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(c => c.Id == cartId);

        if (cart == null)
            throw new KeyNotFoundException("Cart not found");

        var product = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
            throw new KeyNotFoundException("Product not found");

        cart.Products.Add(new CartProduct
        {
            CartId = cartId,
            ProductId = productId
        });
        
        cart.TotalPrice += product.Price;
        
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductInCart(long cartId, long productId)
    {
        var cart = await dbContext.Carts
            .Include(p => p.Products)
                .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(c => c.Id == cartId);
        
        if(cart == null)
            throw new KeyNotFoundException("Cart not found");
        
        var ProductForRemove = cart.Products
            .FirstOrDefault(cp => cp.ProductId == productId);

        if (ProductForRemove == null)
            throw new KeyNotFoundException("Product not found in cart");

        cart.Products.Remove(ProductForRemove);
        cart.TotalPrice -= ProductForRemove.Product.Price;
        
        await dbContext.SaveChangesAsync();
    }

    /*public async Task DeleteProductsInCart(long cartId)
    {
        var cart = await dbContext.Carts
            .AsNoTracking()
            .Include(c => c.Products)
                .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(c => c.Id == cartId);
        
        if(cart == null)
            throw new KeyNotFoundException("Feedback not found");

        cart.Products.Clear();
        cart.TotalPrice = 0;
        await dbContext.SaveChangesAsync();
    }*/
}