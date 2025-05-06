using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs.Request;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Services;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("products")]
public class ProductController(ProductService productService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<GetProductDto>> GetAllProducts()
    {
        var products = await productService.GetProducts();

        return Ok(products);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<GetProductDto>> GetProductById(long productId)
    {
        var product = await productService.GetProductById(productId);
        
        return Ok(product);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto)
    {
        await productService.CreateProduct(addProductDto);
        return Ok();
    }

    [HttpPut("{productId}/update")]
    public async Task<IActionResult> UpdateProduct([FromBody] AddProductDto addProduct, long productId)
    {
        await productService.UpdateProduct(addProduct, productId);
        return Ok();
    }

    [HttpDelete("{productId}/delete")]
    public async Task<IActionResult> DeleteProduct(long productId)
    {
        await productService.DeleteProduct(productId);
        return Ok();
    }
}