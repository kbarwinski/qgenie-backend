using AutoMapper;
using MediatR;
using QGenieBackend.Handlers.Messages.DTOs;
using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Messages;
using QGenieBackend.Services;

namespace QGenieBackend.Handlers.Messages.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageDTO>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMessageCommandHandler> _logger;

        private readonly IQueryGeneratorService _queryGeneratorService;
        private readonly ILLMService _llmService;

        private readonly static string MessagePrefix =
            "Create a set of interview questions based on the following information, provide just enumerated questions list without any additional elements: \n\n";

        private readonly static string MessageSuffix = "";

        public CreateMessageCommandHandler(IMessageRepository messageRepository,
            IMapper mapper,
            IQueryGeneratorService queryGeneratorService,
            ILLMService llmService,
            ILogger<CreateMessageCommandHandler> logger)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;

            _queryGeneratorService = queryGeneratorService;
            _llmService = llmService;
            _logger = logger;
        }

        public async Task<MessageDTO> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(request.MessageDTO);
            message.InterviewRefId = request.InterviewRefId;

            var query = _queryGeneratorService.GenerateQueryFromPOCO(message);
            message.Query = MessagePrefix + query + MessageSuffix;

            _logger.LogInformation($"Sending query to LLM:\n{message.Query}");

            message.Response = await _llmService.SendQueryAsync(message.Query);

            _logger.LogInformation($"LLM response:\n{message.Response}");

            await _messageRepository.CreateAsync(message);

            return _mapper.Map<MessageDTO>(message);
        }
    }
}
