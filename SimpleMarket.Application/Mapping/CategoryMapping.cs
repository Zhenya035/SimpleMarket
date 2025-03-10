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
            Products = category.Products.Select(p => ProductMapping.MapToGetProductDto(p)).ToList()
        };
}