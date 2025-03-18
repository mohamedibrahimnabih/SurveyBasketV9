using SurveyBasketV9.Api.Models;

namespace SurveyBasketV9.Api.DTOs.Requests
{
    public class PollRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        //public static explicit operator Poll(PollRequest pollRequest)
        //{
        //    return new()
        //    {
        //        Title = pollRequest.Title,
        //        Description = pollRequest.Description
        //    };
        //}
    }
}
