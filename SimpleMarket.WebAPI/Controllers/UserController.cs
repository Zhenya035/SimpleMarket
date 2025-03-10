using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Models;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> Get()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("users/{id}")]
    public async Task<ActionResult<User>> Get(long id)
    {
        try
        {
            var user = await userService.GetUserById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("users/{userId}/favorite/add/{productId}")]
    public async Task<IActionResult> AddFavorite(long productId, long userId)
    {
        try
        {
            await userService.AddFavouriteProduct(productId, userId);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpPost("users/add")]
    public async Task<IActionResult> Add([FromBody] AddUserDTO newAddUser)
    {
        var user = new User
        {
            Role = newAddUser.Role,
            Username = newAddUser.Username,
            Sex = newAddUser.Sex,
            Password = newAddUser.Password,
            Email = newAddUser.Email,
            PhoneNumber = newAddUser.PhoneNumber
        };
        
        try
        {
            await userService.AddUser(user);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut("users/{id}/update")]
    public async Task<IActionResult> Update([FromBody] AddUserDTO newAddUser, long id)
    {
        var user = new User
        {
            Role = newAddUser.Role,
            Username = newAddUser.Username,
            Sex = newAddUser.Sex,
            Password = newAddUser.Password,
            Email = newAddUser.Email,
            PhoneNumber = newAddUser.PhoneNumber
        };
        try
        {
            await userService.UpdateUser(user, id);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpDelete("users/{id}/delete")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await userService.DeleteUser(id);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}