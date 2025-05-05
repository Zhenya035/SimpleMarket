using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class HistoryService(IHistoryRepository historyRepository)
{
    public async Task<List<History>> GetHistoryByUser(long userId)
    {
        var histories = await historyRepository.GetHistoryByUser(userId);
            
        if (histories.Count == 0)
            throw new KeyNotFoundException("History is empty");
            
        return histories;
    }

    public async Task AddProduct(long productId, long historyId)
    {
        await historyRepository.AddProduct(productId, historyId);
    }
    
    public async Task CreateHistory(long userId)
    {
        var cart = new History()
        {
            UserId = userId
        };

        await historyRepository.CreateHistory(cart);
    }

    public async Task DeleteHistory(long id)
    {
            await historyRepository.DeleteHistory(id);
    }
}