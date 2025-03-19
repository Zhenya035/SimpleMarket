using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICategoryRepository
{
    public Task<List<Category>> GetAllCategories();
    public Task<Category> GetCategoryById(long id);
    public Task AddCategory(Category category);
    public Task UpdateCategory(Category category, long categoryID);
    public Task DeleteCategory(long id);
}