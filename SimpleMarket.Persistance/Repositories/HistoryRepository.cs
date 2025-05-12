using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class HistoryRepository(SimpleMarketDbContext dbContext) : IHistoryRepository
{
    public async Task<History> GetHistoryById(long id)
    {
        var history = await dbContext.Histories
            .AsNoTracking()
            .Include(h => h.Products)
                .ThenInclude(hp => hp.Product)
            .Include(h => h.User)
            .FirstOrDefaultAsync(h => h.Id == id);
        
        if (history == null)
            throw new KeyNotFoundException("History not found");
        
        return history;
    }
    
    public async Task<History> GetHistoryByUser(long userId)
    {
        var history = await dbContext.Histories
            .AsNoTracking()
            .Include(h => h.Products)
                .ThenInclude(hp => hp.Product)
                    .ThenInclude(p => p.Category)
            .Include(h => h.User)
            .FirstOrDefaultAsync(h => h.UserId == userId);
        
        if (history == null)
            throw new KeyNotFoundException("History not found");
        
        return history;
    }

    public async Task AddProduct(long productId, long historyId)
    {
        var history = await dbContext.Histories
            .Include(h => h.Products)
                .ThenInclude(hp => hp.Product)
            .FirstOrDefaultAsync(h => h.Id == historyId);
        
        if(history == null)
            throw new KeyNotFoundException("History not found");
        
        var product = dbContext.Products.Any(p => p.Id == productId);
        if(!product)
            throw new KeyNotFoundException("Product not found");
        
        history.Products.Add(new HistoryProduct()
        {
            ProductId = productId,
            HistoryId = historyId
        });
        await dbContext.SaveChangesAsync();
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
}