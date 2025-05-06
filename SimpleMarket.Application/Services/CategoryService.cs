using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;

namespace SimpleMarket.Application.Services;

public class CategoryService(ICategoryRepository repository)
{
    public async Task<List<GetCategoryDto>> GetCategoriesAsync()
    {
        var categories = await repository.GetAllCategories();
        return categories.Select(CategoryMapping.MapToGetCategoryDto).ToList();
    }

    public async Task<GetCategoryDto> GetCategoryByIdAsync(long id)
    {
        var category = await repository.GetCategoryById(id);
        return CategoryMapping.MapToGetCategoryDto(category);
    }

    public async Task AddCategoryAsync(AddOrUpdateCategoryDto category)
    {
        await repository.AddCategory(CategoryMapping.MapFromAddCategoryDto(category));
    }

    public async Task UpdateCategoryAsync(AddOrUpdateCategoryDto category, long id)
    {
        await repository.UpdateCategory(CategoryMapping.MapFromAddCategoryDto(category), id);
    }

    public async Task DeleteCategoryAsync(long id)
    {
        await repository.DeleteCategory(id);
    }
}