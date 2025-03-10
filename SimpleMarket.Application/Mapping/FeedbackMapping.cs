using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Mapping;

public class FeedbackMapping
{
    public static GetFeedbackDto MapToGetFeedbackDto(Feedback feedback) =>
        new GetFeedbackDto()
        {
            Id = feedback.Id,
            Text = feedback.Text,
            Date = feedback.Date,
            Evaluation = feedback.Evaluation,
            UserName = feedback.User.Username,
            ProductName = feedback.Product.Name
        };
}