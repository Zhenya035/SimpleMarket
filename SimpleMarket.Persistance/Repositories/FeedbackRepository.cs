using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class FeedbackRepository(SimpleMarketDbContext dbContext) : IFeedbackRepository
{
    public async Task<List<Feedback>> GetAllFeedbacksByUser(long userId)
    {
        var feedback = await dbContext.Feedbacks
            .AsNoTracking()
            .Include(f => f.User)
            .Include(f => f.Product)
            .Where(f => f.UserId == userId)
            .ToListAsync();
        
        return feedback;
    }

    public async Task<List<Feedback>> GetAllFeedbacksByProduct(long productId)
    {
        var feedbacks = await dbContext.Feedbacks
            .AsNoTracking()
            .Include(f => f.User)
            .Include(f => f.Product)
            .Where(f => f.ProductId == productId)
            .ToListAsync();
        
        return feedbacks;
    }

    public async Task AddFeedback(Feedback feedback)
    {
        if (feedback == null)
            throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");

        await dbContext.Feedbacks.AddAsync(feedback);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateFeedback(Feedback feedback, long feedbackId)
    {
        if(feedback == null)
            throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");
        
        var foundFeedback =  await dbContext.Feedbacks
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == feedbackId);
        
        if(foundFeedback == null)
            throw new KeyNotFoundException("Feedback not found");

        await dbContext.Feedbacks
            .Where(f => f.Id == foundFeedback.Id)
            .ExecuteUpdateAsync(f => f
                .SetProperty(f => f.Text, feedback.Text)
                .SetProperty(f => f.Date, DateOnly.FromDateTime(DateTime.Now))
                .SetProperty(f => f.Evaluation, feedback.Evaluation)
            );
    }

    public async Task DeleteFeedback(long id)
    {
        var foundFeedback = await dbContext.Feedbacks
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);
        
        if(foundFeedback == null)
            throw new KeyNotFoundException("Feedback not found");

        await dbContext.Feedbacks
            .Where(f => f.Id == id)
            .ExecuteDeleteAsync();
    }
}