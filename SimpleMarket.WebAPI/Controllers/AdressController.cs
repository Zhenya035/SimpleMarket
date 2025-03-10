using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Models;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdressController(AddressService addressService) : ControllerBase
{
    [HttpGet("{userId}/addresses")]
    public async Task<ActionResult<List<Address>>> GetAddresses(long userId)
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

    [HttpPost("{userId}/addresses/add")]
    public async Task<IActionResult> AddAddress([FromBody] GetUserAddressDTO newGetUserAddress, long userId)
    {
        var address = new Address()
        {
            Country = newGetUserAddress.Country,
            City = newGetUserAddress.City,
            Street = newGetUserAddress.Street,
            HomeNumber = newGetUserAddress.HomeNumber,
            PostalCode = newGetUserAddress.PostalCode,
            UserId = userId
        };
        
        try
        {
            await addressService.AddAddress(address, userId);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut("{userId}/addresses/{addressId}/update")]
    public async Task<IActionResult> UpdateAddress([FromBody] GetUserAddressDTO newGetUserAddress, long userId)
    {
        var address = new Address()
        {
            Country = newGetUserAddress.Country,
            City = newGetUserAddress.City,
            Street = newGetUserAddress.Street,
            HomeNumber = newGetUserAddress.HomeNumber,
            PostalCode = newGetUserAddress.PostalCode,
            UserId = userId
        };
        
        try
        {
            await addressService.UpdateAddress(address, userId);
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

    [HttpDelete("{userId}/addresses/{addressId}")]
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