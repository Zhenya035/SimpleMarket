namespace SimpleMarket.Application.Services;

public class HistoryProductService(IHistoryProductRepository repository)
{
    public async Task DeleteHistory(long historyId)
    {
        await repository.DeleteHistory(historyId);
    }
}