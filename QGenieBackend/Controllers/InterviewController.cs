using MediatR;
using Microsoft.AspNetCore.Mvc;
using QGenieBackend.Handlers.Interviews.Commands.CreateInterview;
using QGenieBackend.Handlers.Interviews.Commands.CreateInterviewMessage;
using QGenieBackend.Handlers.Interviews.DTOs;
using QGenieBackend.Handlers.Interviews.Queries.GetInterviewByRefId;
using QGenieBackend.Handlers.Messages.DTOs;

namespace QGenieBackend.Controllers
{
    [ApiController]
    [Route("api/interviews")]
    public class InterviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InterviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<InterviewDTO>> CreateInterview([FromBody] CreateInterviewCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetInterviewByRefId), new { refId = result.RefId }, result);
        }

        [HttpGet("{refId}")]
        public async Task<ActionResult<InterviewDTO>> GetInterviewByRefId(int refId)
        {
            var query = new GetInterviewByRefIdQuery { RefId = refId };

            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("{refId}/query")]
        public async Task<ActionResult<MessageDTO>> CreateInterviewMessage(int refId, [FromBody] MessageCreationDTO dto)
        {
            var result = await _mediator.Send(new CreateInterviewMessageCommand { InterviewRefId = refId, MessageDTO = dto });
            return CreatedAtAction(
                "GetMessageById",
                "Message",
                new { id = result.Id.ToString() },
                result
            );
        }
    }
}
