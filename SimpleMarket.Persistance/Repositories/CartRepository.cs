using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CartRepository(SimpleMarketDbContext dbContext) : ICartRepository
{
    public async Task<Cart> GetCartByUser(long userId)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(u => u.Cart)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        return user.Cart;
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

    public async Task DeleteCart(long id)
    {
        var cart = await dbContext.Carts
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cart == null)
            throw new KeyNotFoundException("Cart not found");

        await dbContext.Carts
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<Product>> GetAllProductsInCart(long cartId)
    {
        var cart = await dbContext.Carts
            .AsNoTracking()
            .Include(p => p.Products)
            .FirstOrDefaultAsync(c => c.Id == cartId);

        if (cart == null)
            throw new KeyNotFoundException("Cart not found");

        return cart.Products;
    }

    public async Task AddProductToCart(long cartId, long productId)
    {
        var cart = await dbContext.Carts
            .Include(p => p.Products)
            .FirstOrDefaultAsync(c => c.Id == cartId);

        if (cart == null)
            throw new KeyNotFoundException("Cart not found");

        var product = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
            throw new KeyNotFoundException("Product not found");

        if (cart.Products.Any(p => p.Id == productId))
            throw new Exception("Product already added");

        cart.Products.Add(product);
        cart.TotalPrice += product.Price;
        
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductInCart(long cartId, long productId)
    {
        var cart = await dbContext.Carts
            .AsNoTracking()
            .Include(p => p.Products)
            .FirstOrDefaultAsync(c => c.Id == cartId);
        
        if(cart == null)
            throw new KeyNotFoundException("Cart not found");
        
        var product = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);
        
        if(product == null)
            throw new KeyNotFoundException("Product not found");

        cart.Products.Remove(product);
        cart.TotalPrice -= product.Price;
        
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductsInCart(long cartId)
    {
        var foundCart = await dbContext.Carts
            .AsNoTracking()
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == cartId);
        
        if(foundCart == null)
            throw new KeyNotFoundException("Feedback not found");

        await dbContext.Carts
            .Where(c => c.Id == cartId)
            .ExecuteUpdateAsync(c => c
                .SetProperty(c => c.Products, new List<Product>()));
    }
}