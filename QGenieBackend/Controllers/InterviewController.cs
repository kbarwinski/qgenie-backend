using MediatR;
using Microsoft.AspNetCore.Mvc;
using QGenieBackend.Handlers.Messages.Commands;
using QGenieBackend.Handlers.Messages.DTOs;
using QGenieBackend.Handlers.Messages.Queries.GetLastInterviewMessage;

namespace QGenieBackend.Controllers
{
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

            [HttpPost("{refId}/messages")]
            public async Task<ActionResult<MessageDTO>> CreateMessage(int refId, [FromBody] MessageCreationDTO dto)
            {
                var result = await _mediator.Send(new CreateMessageCommand() { InterviewRefId = refId, MessageDTO = dto });

                return Ok(result);
            }

            [HttpGet("{refId}/lastmessage")]
            public async Task<ActionResult<MessageDTO>> GetLastInterviewMessage(int refId)
            {
                var query = new GetLastInterviewMessageQuery { InterviewRefId = refId };

                var result = await _mediator.Send(query);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
        }
    }
}
