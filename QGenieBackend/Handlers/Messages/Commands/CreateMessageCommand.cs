using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;

namespace QGenieBackend.Handlers.Messages.Commands
{
    public class CreateMessageCommand : IRequest<MessageDTO>
    {
        public int InterviewRefId { get; set; }
        public MessageCreationDTO MessageDTO { get; set; }
    }
}
