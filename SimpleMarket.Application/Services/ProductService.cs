using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class ProductService(IProductRepository repository)
{
    public async Task<List<Product>> GetProducts()
    {
        var products = await GetProducts();
            
        if(products.Count == 0)
            throw new Exception("No products found");
            
        return products; 
    }

    public async Task<Product> GetProductById(int id)
    {
        return await GetProductById(id);
    }

    public async Task CreateProduct(Product product)
    {
        await CreateProduct(product);
    }

    public async Task UpdateProduct(Product product, long id)
    {
        if(product == null)
            throw new NullReferenceException("Product cannot be null");
        
        await UpdateProduct(product, id);
    }

    public async Task DeleteProduct(long id)
    {
        await DeleteProduct(id);
    }
}