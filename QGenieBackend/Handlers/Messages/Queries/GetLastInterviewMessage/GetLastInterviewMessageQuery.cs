using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;

namespace QGenieBackend.Handlers.Messages.Queries.GetLastInterviewMessage
{
    public class GetLastInterviewMessageQuery : IRequest<MessageDTO?>
    {
        public int InterviewRefId { get; set; }
    }
}
