using Microsoft.AspNetCore.Mvc;
using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.Services;
using SimpleMarket.Core.Models;

namespace SimpleMarket.WebAPI.Controllers;

[ApiController]
[Route("addresses")]
public class AddressesController(AddressService addressService) : ControllerBase
{
    [HttpGet("user/{userId}/all")]
    public async Task<ActionResult<List<Address>>> GetAddressesByUserId(long userId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var addresses = await addressService.GetAddressesByUser(userId);
        return Ok(addresses);

    }

    [HttpGet("{addressId}")]
    public async Task<ActionResult<List<Address>>> GetAddressesById(long addressId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var addresses = await addressService.GetAddressesById(addressId);
        return Ok(addresses);
    }
    
    [HttpPost("{userId}/add")]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressDto newAddress, long userId)
    {
        await addressService.AddAddress(newAddress, userId);
        return Ok();
    }

    [HttpPut("{addressId}/update")]
    public async Task<IActionResult> UpdateAddress([FromBody] AddAddressDto newAddress, long addressId)
    {
        await addressService.UpdateAddress(newAddress, addressId);
        return Ok();
    }

    [HttpDelete("{addressId}/delete")]
    public async Task<IActionResult> DeleteAddress(long addressId)
    {
        await addressService.DeleteAddress(addressId);
        return Ok();
    }
}