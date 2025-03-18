using SurveyBasketV9.Api.DTOs.Requests;
using SurveyBasketV9.Api.Models;

namespace SurveyBasketV9.Api.DTOs.Responses
{
    public class PollResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        //public static explicit operator PollResponse(Poll poll)
        //{
        //    return new()
        //    {
        //        Id = poll.Id,
        //        Title = poll.Title,
        //        Description = poll.Description
        //    };
        //}
    }
}
