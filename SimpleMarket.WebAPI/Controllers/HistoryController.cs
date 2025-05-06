using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Application.Services;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("history")]
public class HistoryController(HistoryService historyService, ProductService productService) : ControllerBase
{
    [HttpGet("{historyId}")]
    public async Task<ActionResult<GetHistoryDto>> GetHistoryById(long historyId)
    {
        var history = await historyService.GetHistoryById(historyId);
        
        return Ok(HistoryMapping.MapToGetHistoryDto(history));
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<GetHistoryDto>> GetHistoryByUser(long userId)
    {
        var history = await historyService.GetHistoryByUser(userId);
        
        return Ok(HistoryMapping.MapToGetHistoryDto(history));
    }

    [HttpPost("{historyId}/add/{productId}")]
    public async Task<IActionResult> AddProductInHistory(long historyId, long productId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await productService.GetProductById(productId);
        await historyService.GetHistoryById(historyId);
        
        await historyService.AddProduct(productId, historyId);
        
        return Ok();
    }

    [HttpDelete("{historyId}/remove")]
    public async Task<IActionResult> RemoveHistory(long historyId)
    {
        await historyService.DeleteHistory(historyId);
        
        return Ok();
    }
}