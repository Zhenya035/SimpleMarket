using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICategoryRepository
{
    public Task<List<Category>> GetAllCategories();
    public Task<Category> GetCategoryById(long id);
    public Task<List<Product>> GetProductsByCategoryId(long id);
    public Task AddCategory(Category category);
    public Task AddProductInCategoryById(Product product, long CategoryId);
    public Task UpdateCategory(Category category);
    public Task DeleteCategory(long id);
}