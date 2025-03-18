using Mapster;
using SurveyBasketV9.Api.DTOs.Requests;
using SurveyBasketV9.Api.DTOs.Responses;
using SurveyBasketV9.Api.Models;

namespace SurveyBasketV9.Api.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PollRequest, Poll>()
                .Map(des => des.Notes, src => src.Description);

            config.NewConfig<Poll, PollResponse>()
                .Map(des => des.Description, src => src.Notes);
        }
    }
}
