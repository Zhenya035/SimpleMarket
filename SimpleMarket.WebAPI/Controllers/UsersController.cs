using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Request;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Models;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("users")]
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

    [HttpPost("login")]
    public async Task<ActionResult<long>> Get([FromBody] LoginUser login)
    {
        var userId = await userService.Login(login);
        return Ok(userId);
    }
    
    [HttpPost("{userId}/favorite/add/{productId}")]
    public async Task<IActionResult> AddFavorite(long productId, long userId)
    {
        await userService.AddFavouriteProduct(productId, userId);
        return Ok();
    }
    
    [HttpGet("{userId}/favourite")]
    public async Task<IActionResult> AllFavorite(long userId)
    {
        var products = await userService.GetFavouriteProducts(userId);
        
        return Ok(products);
    }
    
    [HttpPost("registration")]
    public async Task<ActionResult<long>> Add([FromBody] AddUserDto newUser)
    {
        var userId = await userService.AddUser(newUser);
        return Ok(userId);
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