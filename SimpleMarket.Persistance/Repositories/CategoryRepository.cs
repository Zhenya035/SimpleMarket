using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task<List<Category>> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetProductsByCategoryId(long id)
    {
        throw new NotImplementedException();
    }

    public Task AddCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task AddProductInCategoryById(Product product, long CategoryId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategory(long id)
    {
        throw new NotImplementedException();
    }
}