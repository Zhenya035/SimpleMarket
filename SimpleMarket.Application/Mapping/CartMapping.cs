using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class CartMapping
{
    public static GetCartDto MapToGetCartDto(Cart cart) => 
        new GetCartDto()
        {
            Id = cart.Id,
            Products = cart.Products.Select(p => ProductMapping.MapToGetProductDto(p)).ToList(),
            TotalPrice = cart.TotalPrice
        };
    
}