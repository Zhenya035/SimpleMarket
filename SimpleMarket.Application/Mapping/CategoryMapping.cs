using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class CategoryMapping
{
    public static GetCategoryDto MapToGetCategoryDto(Category category) =>
        new GetCategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            Products = category.Products.Select(p => p.Name).ToList()
        };

    public static Category MapFromAddCategoryDto(AddOrUpdateCategoryDto categoryDto) =>
        new Category()
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
        };
}