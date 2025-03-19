using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IProductRepository
{
    public Task<List<Product>> GetAllProducts();
    public Task<Product> GetProductById(long id);
    public Task CreateProduct(Product product);
    public Task UpdateProduct(Product product, long id);
    public Task DeleteProduct(long id);
}