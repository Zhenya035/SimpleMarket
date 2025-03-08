using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<List<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(long id)
    {
        throw new NotImplementedException();
    }

    public Task CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(long id)
    {
        throw new NotImplementedException();
    }
}