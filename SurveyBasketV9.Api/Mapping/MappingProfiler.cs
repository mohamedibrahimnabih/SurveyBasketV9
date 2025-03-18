using SurveyBasketV9.Api.DTOs.Requests;
using SurveyBasketV9.Api.DTOs.Responses;
using SurveyBasketV9.Api.Models;

namespace SurveyBasketV9.Api.Mapping
{
    public static class MappingProfiler
    {
        public static PollResponse MapToPollResponse(this Poll poll)
        {
            return new()
            {
                Id = poll.Id,
                Title = poll.Title,
                Description = poll.Notes
            };
        }

        public static IEnumerable<PollResponse> MapToPollsResponse(this IEnumerable<Poll> polls)
        {
            return polls.Select(MapToPollResponse);
        }

        public static Poll MapToPoll(this PollRequest pollRequest)
        {
            return new()
            {
                Title = pollRequest.Title,
                Notes = pollRequest.Description
            };
        }
    }
}
