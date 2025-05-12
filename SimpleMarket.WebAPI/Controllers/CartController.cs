using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Services;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("cart")]
public class CartController(CartService cartService) : ControllerBase
{
    [HttpGet("{userId}/products")]
    public async Task<ActionResult<List<GetProductDto>>> GetCartProducts(long userId)
    {
        var products = await cartService.GetCartProducts(userId);
        return Ok(products);
    }
    
    [HttpPost("{userId}/products/add/{productId}")]
    public async Task<ActionResult> AddCartProduct(long userId, long productId)
    {
        await cartService.AddProduct(userId, productId);
        return Ok();
    }

    [HttpDelete("{cartId}/products/remove/{productId}")]
    public async Task<ActionResult> RemoveCartProduct(long cartId, long productId)
    {
        await cartService.RemoveProduct(cartId, productId);
        return Ok();
    }

    [HttpDelete("{cartId}/products/remove")]
    public async Task<ActionResult> RemoveCartAllProducts(long cartId)
    {
        await cartService.RemoveAllProducts(cartId);
        return Ok();
    }
}