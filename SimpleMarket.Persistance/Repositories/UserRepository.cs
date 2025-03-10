using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class UserRepository(SimpleMarketDbContext dbContext) : IUserRepository
{
    public async Task<List<User>> GetAllUsers()
    {
        return await dbContext.Users
            .AsNoTracking()
            .Include(u =>u.FavouriteProducts)
            .Include(u =>u.Feedbacks)
            .Include(u =>u.Addresses)
            .Include(u => u.Cart)
            .Include(u => u.History)
            .ToListAsync();
    }

    public async Task<User> GetUserById(long id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddFavouriteProduct(long userId, long productId)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(u => u.FavouriteProducts)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        var product = dbContext.Products
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == productId);
        
        if (!user.FavouriteProducts.Contains(product))
        {
            user.FavouriteProducts.Add(product);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<long> AddUser(User user)
    {
        if(user == null)
            throw new ArgumentNullException(nameof(user), "User cannot be null");

        try
        {
            var newUser = await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            
            return newUser.Entity.Id;
        }
        catch (Exception e)
        {
            throw new Exception("Error when creating a user");
        }
    }

    public async Task UpdateUser(User user, long userId)
    {
        if(user == null)
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        
        await dbContext.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(u => u.
                    SetProperty(u => u.Role, user.Role)
                    .SetProperty(u => u.Username, user.Username)
                    .SetProperty(u => u.Sex, user.Sex)
                    .SetProperty(u => u.Password, user.Password)
                    .SetProperty(u => u.Email, user.Email)
                    .SetProperty(u => u.PhoneNumber, user.PhoneNumber));
    }

    public async Task DeleteUser(long id)
    {
        await dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();
    }
}