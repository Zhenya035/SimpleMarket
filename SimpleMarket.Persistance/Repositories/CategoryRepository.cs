using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CategoryRepository(SimpleMarketDbContext dbContext) : ICategoryRepository
{
    public async Task<List<Category>> GetAllCategories() =>
        await dbContext.Categories
            .AsNoTracking()
            .ToListAsync();

    public async Task<Category> GetCategoryById(long id)
    {
        var category = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if(category == null)
            throw new KeyNotFoundException("Category not found");
        
        return category;
    }

    public async Task AddCategory(Category category)
    {
        if(category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");

        try
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task UpdateCategory(Category category, long categoryId)
    {
        if(category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null");
        
        var findCategory = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId);
        
        if(findCategory == null)
            throw new KeyNotFoundException("Category not found");

        await dbContext.Categories
            .Where(c => c.Id == categoryId)
            .ExecuteUpdateAsync(c => c
                .SetProperty(c => c.Name, category.Name)
                .SetProperty(c => c.Description, category.Description));
    }

    public async Task DeleteCategory(long id)
    {
        var category = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if(category == null)
            throw new KeyNotFoundException("Category not found");
        
        await dbContext.Categories
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}