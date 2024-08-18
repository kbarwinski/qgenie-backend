using MediatR;
using Microsoft.AspNetCore.Mvc;
using QGenieBackend.Handlers.Interviews.DTOs;
using QGenieBackend.Handlers.Interviews.Queries.GetInterviewByRefId;
using QGenieBackend.Handlers.Messages.Queries.GetMessageById;

namespace QGenieBackend.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewDTO>> GetMessageById(string id)
        {
            var query = new GetMessageByIdQuery { Id = new Guid(id) };

            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
