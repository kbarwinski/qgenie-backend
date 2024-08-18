using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;

namespace QGenieBackend.Handlers.Interviews.Commands.CreateInterviewMessage
{
    public class CreateInterviewMessageCommand : IRequest<MessageDTO>
    {
        public int InterviewRefId { get; set; }
        public MessageCreationDTO MessageDTO { get; set; }
    }
}
