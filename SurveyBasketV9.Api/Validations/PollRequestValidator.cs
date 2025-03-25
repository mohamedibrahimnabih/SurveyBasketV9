using FluentValidation;
using SurveyBasketV9.Api.DTOs.Requests;

namespace SurveyBasketV9.Api.Validations
{
    public class PollRequestValidator : AbstractValidator<PollRequest>
    {
        public PollRequestValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty()
                .WithMessage("Please ensure you have entered your {PropertyName}");
        }
    }
}
