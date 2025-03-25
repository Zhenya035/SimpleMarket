using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class CategoryService(ICategoryRepository repository)
{
    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var categories = await repository.GetAllCategories();
            return categories;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        try
        {
            var category = await repository.GetCategoryById(id);
            return category;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task AddCategoryAsync(Category category)
    {
        try
        {
            await repository.AddCategory(category);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateCategoryAsync(Category category, long id)
    {
        try
        {
            await repository.UpdateCategory(category, id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteCategoryAsync(long id)
    {
        try
        {
            await repository.DeleteCategory(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}