using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class HistoryService(IHistoryRepository historyRepository)
{
    public async Task<List<History>> GetHistoryByUser(long userId)
    {
        try
        {
            var histories = await historyRepository.GetHistoryByUser(userId);
            
            if (histories.Count == 0)
                throw new KeyNotFoundException("History is empty");
            
            return histories;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task AddProduct(long productId, long historyId)
    {
        try
        {
            await historyRepository.AddProduct(productId, historyId);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task CreateHistory(long userId)
    {
        var cart = new History()
        {
            UserId = userId
        };

        try
        {
            await historyRepository.CreateHistory(cart);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteHistory(long id)
    {
        try
        {
            await historyRepository.DeleteHistory(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}