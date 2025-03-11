using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Models;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController(AddressService addressService) : ControllerBase
{
    [HttpGet("{userId}/all")]
    public async Task<ActionResult<List<Address>>> GetAddressesById(long userId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var addresses = await addressService.GetAddressesByUser(userId);
            return Ok(addresses);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("{userId}/add")]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressDto newAddress, long userId)
    {
        try
        {
            await addressService.AddAddress(newAddress, userId);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut("{userId}/{addressId}/update")]
    public async Task<IActionResult> UpdateAddress([FromBody] AddAddressDto newAddress, long userId, long addressId)
    {
        try
        {
            await addressService.UpdateAddress(newAddress, addressId, userId);
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

    [HttpDelete("{userId}/{addressId}/delete")]
    public async Task<IActionResult> DeleteAddress(long userId, long addressId)
    {
        try
        {
            await addressService.DeleteAddress(addressId, userId);
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