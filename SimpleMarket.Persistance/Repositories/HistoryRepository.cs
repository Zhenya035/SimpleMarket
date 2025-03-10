using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class HistoryRepository(SimpleMarketDbContext dbContext) : IHistoryRepository
{
    public Task<List<History>> GetHistoryByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(Product product, long historyId)
    {
        throw new NotImplementedException();
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

    public Task UpdateHistory(History history)
    {
        throw new NotImplementedException();
    }

    public Task DeleteHistory(long id)
    {
        throw new NotImplementedException();
    }
}