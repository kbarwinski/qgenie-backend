using AutoMapper;
using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;
using QGenieBackend.Repositories.Messages;

namespace QGenieBackend.Handlers.Messages.Queries.GetMessageById
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageDTO>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageByIdQueryHandler(IMessageRepository MessageRepository, IMapper mapper)
        {
            _messageRepository = MessageRepository;
            _mapper = mapper;
        }

        public async Task<MessageDTO> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetByIdAsync(request.Id);

            return _mapper.Map<MessageDTO>(message);
        }
    }
}
