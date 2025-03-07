using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IHistoryRepository
{
    public Task<List<History>> GetHistoryByUser(long userId);
    public Task AddProduct(Product product, long historyId);
    public Task CreateHistory(History history);
    public Task UpdateHistory(History history);
    public Task DeleteHistory(long id);
}