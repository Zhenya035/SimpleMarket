using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class HistoryService(IHistoryRepository historyRepository)
{
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
            throw e;
        }
    }
}