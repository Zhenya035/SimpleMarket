using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IHistoryRepository
{
    public Task<History> GetHistoryById(long id);
    public Task<History> GetHistoryByUser(long userId);
    public Task AddProduct(long productId, long historyId);
    public Task CreateHistory(History history);
}