using SimpleMarket.Application.DTOs;
using SimpleMarket.Application.DTOs.Request;
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

    public static Feedback MapFromAddFeedbackDto(AddFeedbackDto feedbackDto, long userId, long productId) =>
        new Feedback()
        {
            Text = feedbackDto.Text,
            Date = feedbackDto.Date,
            Evaluation = feedbackDto.Evaluation,
            UserId = userId,
            ProductId = productId
        };
}