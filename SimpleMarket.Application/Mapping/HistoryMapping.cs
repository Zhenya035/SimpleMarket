using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class HistoryMapping
{
    public static GetHistoryDto MapToGetHistoryDto(History history) =>
        new GetHistoryDto()
        {
            Id = history.Id,
            Products = history.Products.Select(p => ProductMapping.MapToGetProductDto(p)).ToList(),
            UserName = history.User.Username,
        };
}