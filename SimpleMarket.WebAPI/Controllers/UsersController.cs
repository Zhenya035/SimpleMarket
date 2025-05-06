using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Models;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(UserService userService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<List<User>>> Get()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var users = await userService.GetAllUsers();
            return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(long id)
    {
        var user = await userService.GetUserById(id);
        return Ok(user);
    }
    
    [HttpPost("{userId}/favorite/add/{productId}")]
    public async Task<IActionResult> AddFavorite(long productId, long userId)
    {
        await userService.AddFavouriteProduct(productId, userId);
        return Ok();
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddUserDto newUser)
    {
        await userService.AddUser(newUser);
        return Ok();
    }

    [HttpPut("{id}/update")]
    public async Task<IActionResult> Update([FromBody] AddUserDto newUser, long id)
    {
        await userService.UpdateUser(newUser, id);
        return Ok();
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> Delete(long id)
    {
        await userService.DeleteUser(id);
        return Ok();
    }
}