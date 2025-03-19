using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class ProductRepository(SimpleMarketDbContext dbContext) : IProductRepository
{
    public async Task<List<Product>> GetAllProducts()
    {
        return await dbContext.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product> GetProductById(long id)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
            throw new KeyNotFoundException("Product not found");
        
        return product;
    }

    public async Task CreateProduct(Product product)
    {
        if(product == null)
            throw new ArgumentNullException(nameof(product), "Product cannot be null");

        try
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to create product: {e.Message}");
        }
    }

    public async Task UpdateProduct(Product upProduct, long productId)
    {
        if(upProduct == null)
            throw new ArgumentNullException(nameof(upProduct), "Product cannot be null");
        
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == productId);
        
        if(product == null)
            throw new KeyNotFoundException("Product not found");

        await dbContext.Products
            .Where(p => p.Id == productId)
            .ExecuteUpdateAsync(p => p
                .SetProperty(p => p.Name, upProduct.Name)
                .SetProperty(p => p.Description, upProduct.Description)
                .SetProperty(p => p.Price, upProduct.Price)
                .SetProperty(p => p.Images, upProduct.Images)
            );
    }

    public async Task DeleteProduct(long id)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if(product == null)
            throw new KeyNotFoundException("Product not found");

        await dbContext.Products
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();
    }
}