using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Services;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("category")]
public class CategoryController(CategoryService service) : ControllerBase
{
    [HttpGet("get/all")]
    public async Task<ActionResult<List<GetCategoryDto>>> GetCategories()
    {
        var categories = await service.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<GetCategoryDto>> GetCategory(int id)
    {
        var category = await service.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddCategory([FromBody] AddOrUpdateCategoryDto newCategory)
    {
        if(newCategory.Name == string.Empty || newCategory.Description == string.Empty)
            return BadRequest("Category cannot be empty");
        
        await service.AddCategoryAsync(newCategory);
        return Ok();
    }

    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateCategory(long id, AddOrUpdateCategoryDto newCategory)
    {
        if(newCategory.Name == string.Empty || newCategory.Description == string.Empty)
            return BadRequest("Category cannot be empty");
        
        await service.UpdateCategoryAsync(newCategory, id);
        return Ok();
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteCategory(long id)
    {
        await service.DeleteCategoryAsync(id);
        return Ok();
    }
}