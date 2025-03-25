using Microsoft.EntityFrameworkCore;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class FeedbackRepository(SimpleMarketDbContext dbContext) : IFeedbackRepository
{
    public async Task<List<Feedback>> GetAllFeedbacksByUser(long userId)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(u => u.Feedbacks)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if(user == null)
            throw new KeyNotFoundException("User not found");
        
        return user.Feedbacks;
    }

    public async Task<List<Feedback>> GetAllFeedbacksByProduct(long productId)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .Include(p => p.Feedbacks)
            .FirstOrDefaultAsync(p => p.Id == productId);
        
        if(product == null)
            throw new KeyNotFoundException("Product not found");
        
        return product.Feedbacks;
    }

    public async Task AddFeedback(Feedback feedback)
    {
        if (feedback == null)
            throw new ArgumentNullException(nameof(feedback), "Feedback cannot be null");
        try
        {
            await dbContext.Feedbacks.AddAsync(feedback);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error while adding feedback", e);
        }
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