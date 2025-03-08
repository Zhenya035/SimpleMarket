using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class FeedbackRepository : IFeedbackRepository
{
    public Task<List<Feedback>> GetAllFeedbacksByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Feedback>> GetAllFeedbacksByProduct(long productId)
    {
        throw new NotImplementedException();
    }

    public Task AddFeedback(Feedback feedback)
    {
        throw new NotImplementedException();
    }

    public Task UpdateFeedback(Feedback feedback)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFeedback(long id)
    {
        throw new NotImplementedException();
    }
}