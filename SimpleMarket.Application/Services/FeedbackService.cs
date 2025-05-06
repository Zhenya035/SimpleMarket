using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Request;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class FeedbackService(IFeedbackRepository repository, IUserRepository userRepository, IProductRepository productRepository)
{
    public async Task<List<Feedback>> GetAllFeedbacksByUser(long userId)
    {
        var feedbacks = await repository.GetAllFeedbacksByUser(userId);
        return feedbacks;
    }

    public async Task<List<Feedback>> GetAllFeedbacksByProduct(long productId)
    {
        var feedbacks = await repository.GetAllFeedbacksByProduct(productId);
        return feedbacks;
    }

    public async Task AddFeedback(AddFeedbackDto addFeedbackDto, int userId, int productId)
    {
        if (addFeedbackDto == null)
            throw new ArgumentNullException(nameof(addFeedbackDto), "Feedback cannot be null");
        
        await userRepository.GetUserById(userId);
        await productRepository.GetProductById(productId);
        
        var feedback = FeedbackMapping.MapFromAddFeedbackDto(addFeedbackDto, userId, productId);
    
        await repository.AddFeedback(feedback);
    }

    public async Task UpdateFeedback(Feedback feedback, long id)
    {
        if (feedback == null)
            throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");
        
        await repository.UpdateFeedback(feedback, id);
    }

    public async Task DeleteFeedback(long id)
    {
        await repository.DeleteFeedback(id);
    }
}