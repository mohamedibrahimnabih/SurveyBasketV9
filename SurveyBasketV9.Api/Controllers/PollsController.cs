using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SurveyBasketV9.Api.DTOs.Requests;
using SurveyBasketV9.Api.DTOs.Responses;
using SurveyBasketV9.Api.Mapping;
using SurveyBasketV9.Api.Models;
using SurveyBasketV9.Api.Services.IServices;
using SurveyBasketV9.Api.Validations;

namespace SurveyBasketV9.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollsController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();

            return Ok(polls.Adapt<IEnumerable<PollResponse>>());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var poll = _pollService.GetById(id);

            //if (poll == null)
            //    return NotFound();

            //return Ok(poll);

            return poll == null ? NotFound() : Ok(poll.Adapt<PollResponse>());
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] PollRequest poll/*, [FromServices] IValidator<PollRequest> validator*/)
        {
            //if (!ModelState.IsValid)
            //    return ValidationProblem(ModelState);

            //ValidationResult results = validator.Validate(poll);

            //if (!results.IsValid)
            //{
            //    foreach (var failure in results.Errors)
            //    {
            //        ModelStateDictionary errors = new();
            //        errors.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //        return ValidationProblem(errors);
            //    }
            //}

            var pollCreated = _pollService.Add(poll.Adapt<Poll>());
            return CreatedAtAction(nameof(GetById), new { id = pollCreated.Id }, pollCreated);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PollRequest poll)
        {
            var result = _pollService.Edit(id, poll.Adapt<Poll>());

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _pollService.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
