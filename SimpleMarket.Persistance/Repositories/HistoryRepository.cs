using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class HistoryRepository : IHistoryRepository
{
    public Task<List<History>> GetHistoryByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(Product product, long historyId)
    {
        throw new NotImplementedException();
    }

    public Task CreateHistory(History history)
    {
        throw new NotImplementedException();
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