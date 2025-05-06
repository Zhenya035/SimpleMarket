using SimpleMarket.Application.DTOs.Request;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class ProductMapping
{
    public static GetProductDto MapToGetProductDto(Product product) =>
        new GetProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Images = product.Images,
            CategoryName = product.Category.Name,
            FeedbacksCount = product.Feedbacks.Count
        };

    public static Product MapFromAddProductDto(AddProductDto addProductDto) =>
        new Product()
        {
            Name = addProductDto.Name,
            Description = addProductDto.Description,
            Price = addProductDto.Price,
            Images = addProductDto.Images,
            CategoryId = addProductDto.CategoryId
        };
}