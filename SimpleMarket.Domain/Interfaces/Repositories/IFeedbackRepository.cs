using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface IFeedbackRepository
{
    public Task<List<Feedback>> GetAllFeedbacksByUser(long userId);
    public Task<List<Feedback>> GetAllFeedbacksByProduct(long productId);
    public Task AddFeedback(Feedback feedback);
    public Task UpdateFeedback(Feedback feedback);
    public Task DeleteFeedback(long id);
}