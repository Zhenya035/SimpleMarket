using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Services;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("cart")]
public class CartController(CartService cartService) : ControllerBase
{
    [HttpGet("{cartId}/products")]
    public async Task<ActionResult<List<GetProductDto>>> GetCartProducts(long cartId)
    {
        var products = await cartService.GetCartProducts(cartId);
        return Ok(products);
    }
    
    [HttpPost("{cartId}/products/add/{productId}")]
    public async Task<ActionResult> AddCartProduct(long cartId, long productId)
    {
        await cartService.AddProduct(cartId, productId);
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