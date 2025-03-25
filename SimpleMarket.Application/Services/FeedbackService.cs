using System.Linq.Expressions;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class FeedbackService(IFeedbackRepository repository)
{
    public async Task<List<Feedback>> GetAllFeedbacksByUser(long userId)
    {
        try
        {
            var feedbacks = await repository.GetAllFeedbacksByUser(userId);
            return feedbacks;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<Feedback>> GetAllFeedbacksByProduct(long productId)
    {
        try
        {
            var feedbacks = await repository.GetAllFeedbacksByProduct(productId);
            return feedbacks;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task AddFeedback(Feedback feedback)
    {
        if (feedback == null)
            throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");
        
        try
        {
            await repository.AddFeedback(feedback);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateFeedback(Feedback feedback, long id)
    {
        if (feedback == null)
            throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");
        
        try
        {
            await repository.UpdateFeedback(feedback, id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteFeedback(long id)
    {
        try
        {
            await repository.DeleteFeedback(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}