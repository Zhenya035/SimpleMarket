using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class AddressRepository(SimpleMarketDbContext dbContext) : IAddressRepository
{
    public async Task<List<Address>> GetAllAddressesByUser(long userId)
    {
        return await dbContext.Addresses
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<List<Address>> GetAllAddressesById(long userId)
    {
        return await dbContext.Addresses
            .AsNoTracking()
            .Where(a => a.Id == userId)
            .ToListAsync();
    }

    public async Task AddAddress(Address address, long userId)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address), "Address cannot be null");

        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (user == null)
            throw new ArgumentNullException(nameof(user), "User does not exist");
        
        try
        {
            await dbContext.Addresses.AddAsync(address);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error when creating an adress");
        }
    }

    public async Task UpdateAddress(Address address, long addressId)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address), "Address cannot be null");
        
        await dbContext.Addresses
            .Where(a => a.Id == addressId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(a => a.Country, address.Country)
                .SetProperty(a => a.City, address.City)
                .SetProperty(a => a.Street, address.Street)
                .SetProperty(a => a.HomeNumber, address.HomeNumber)
                .SetProperty(a => a.PostalCode, address.PostalCode)
            );
    }

    public async Task DeleteAddress(long id)
    {
        await dbContext.Addresses
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync();
    }
}   