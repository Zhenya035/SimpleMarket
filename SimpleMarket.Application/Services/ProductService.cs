using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class ProductService(IProductRepository repository)
{
    public async Task<List<Product>> GetProducts()
    {
        try
        {
            var products = await GetProducts();
            
            if(products.Count == 0)
                throw new Exception("No products found");
            
            return products;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Product> GetProductById(int id)
    {
        try
        {
            return await GetProductById(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task CreateProduct(Product product)
    {
        try
        {
            await CreateProduct(product);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateProduct(Product product, long id)
    {
        if(product == null)
            throw new NullReferenceException("Product cannot be null");
        
        try
        {
            await UpdateProduct(product, id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteProduct(long id)
    {
        try
        {
            await DeleteProduct(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}