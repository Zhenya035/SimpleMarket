using Microsoft.EntityFrameworkCore;
using SimpleMarket.Application.Services;

namespace SimpleMarket.Persistance.Repositories;

public class HistoryProductRepository(SimpleMarketDbContext dbContext) : IHistoryProductRepository
{
    public async Task DeleteHistory(long historyId)
    {
        var historyProducts = await dbContext.HistoryProducts
            .Where(c => c.HistoryId == historyId)
            .ToListAsync();
        
        dbContext.HistoryProducts.RemoveRange(historyProducts);
        await dbContext.SaveChangesAsync();
    }
}