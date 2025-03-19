using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class HistoryRepository(SimpleMarketDbContext dbContext) : IHistoryRepository
{
    public async Task<List<History>> GetHistoryByUser(long userId)
    {
        return await dbContext.Histories
            .AsNoTracking()
            .Include(h => h.Products)
            .Where(h => h.UserId == userId)
            .ToListAsync();
    }

    public async Task AddProduct(long productId, long historyId)
    {
        var foundHistory = await dbContext.Histories
            .AsNoTracking()
            .Include(h => h.Products)
            .FirstOrDefaultAsync(h => h.Id == historyId);
        
        if(foundHistory == null)
            throw new KeyNotFoundException("History not found");
        
        var product = dbContext.Products
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == productId);
        
        if(product == null)
            throw new KeyNotFoundException("Product not found");

        try
        {
            foundHistory.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new  Exception(nameof(e));
        }
    }

    public async Task CreateHistory(History history)
    {
        if (history == null)
            throw new ArgumentNullException(nameof(history), "User cannot be null");

        try
        {
            await dbContext.Histories.AddAsync(history);
            await dbContext.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception("Error creating cart", e);
        } 
    }

    public async Task DeleteHistory(long id)
    {
        var history = await dbContext.Histories
            .AsNoTracking()
            .Include(h => h.Products)
            .FirstOrDefaultAsync(h => h.Id == id);
        
        if(history == null)
            throw new KeyNotFoundException("History not found");

        await dbContext.Histories
            .Where(h => h.Id == id)
            .ExecuteUpdateAsync(h => h
                .SetProperty(h => h.Products, new List<Product>()));
    }
}