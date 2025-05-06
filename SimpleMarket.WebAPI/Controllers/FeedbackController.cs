using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs.Request;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Application.Services;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("feedback")]
public class FeedbackController(FeedbackService feedbackService) : ControllerBase
{
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<GetFeedbackDto>> GetFeedbackByUser(int userId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var feedbacks = await feedbackService.GetAllFeedbacksByUser(userId);
        
        var response = feedbacks.Select(FeedbackMapping.MapToGetFeedbackDto).ToList();
        
        return Ok(response);
    }
    
    [HttpGet("product/{productId}")]
    public async Task<ActionResult<GetFeedbackDto>> GetFeedbackByProduct(int productId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var feedbacks = await feedbackService.GetAllFeedbacksByProduct(productId);
        
        var response = feedbacks.Select(FeedbackMapping.MapToGetFeedbackDto).ToList();
        
        return Ok(response);
    }

    [HttpPost("add/{userId}/{productId}")]
    public async Task<IActionResult> AddFeedback([FromBody] AddFeedbackDto feedback, int userId, int productId)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await feedbackService.AddFeedback(feedback, userId, productId);
        
        return Ok();
    }
}