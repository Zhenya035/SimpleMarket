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
            Category = CategoryMapping.MapToGetCategoryDto(product.Category),
            Feedbacks = product.Feedbacks.Select(f => FeedbackMapping.MapToGetFeedbackDto(f)).ToList(),
            History = product.Histories.Select(h => HistoryMapping.MapToGetHistoryDto(h)).ToList(),
            Carts = product.Carts.Select(c => CartMapping.MapToGetCartDto(c)).ToList(),
        };
}