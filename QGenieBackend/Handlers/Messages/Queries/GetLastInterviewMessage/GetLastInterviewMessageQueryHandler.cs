using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;
using QGenieBackend.Repositories.Messages;
using AutoMapper;

namespace QGenieBackend.Handlers.Messages.Queries.GetLastInterviewMessage
{
    public class GetLastInterviewMessageQueryHandler : IRequestHandler<GetLastInterviewMessageQuery, MessageDTO?>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetLastInterviewMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<MessageDTO?> Handle(GetLastInterviewMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetLastMessageByInterviewRefIdAsync(request.InterviewRefId);
            return message != null ? _mapper.Map<MessageDTO>(message) : null;
        }
    }
}