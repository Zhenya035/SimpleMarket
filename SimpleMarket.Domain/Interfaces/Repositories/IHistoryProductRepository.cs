namespace SimpleMarket.Application.Services;

public interface IHistoryProductRepository
{
    public Task DeleteHistory(long historyId);
}