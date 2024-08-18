using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;

namespace QGenieBackend.Handlers.Messages.Queries.GetMessageById
{
    public class GetMessageByIdQuery : IRequest<MessageDTO>
    {
        public Guid Id { get; set; }
    }
}
