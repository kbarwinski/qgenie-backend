using AutoMapper;
using MediatR;
using QGenieBackend.Exceptions;
using QGenieBackend.Handlers.Messages.DTOs;
using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Interviews;
using QGenieBackend.Repositories.Messages;
using QGenieBackend.Services;
using System.Text;

namespace QGenieBackend.Handlers.Interviews.Commands.CreateInterviewMessage
{
    public class CreateInterviewMessageHandler : IRequestHandler<CreateInterviewMessageCommand, MessageDTO>
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInterviewMessageHandler> _logger;

        private readonly IQueryGeneratorService _queryGeneratorService;
        private readonly ILLMService _llmService;

        private readonly static string MessageSuffix = "Create a set of interview questions based on the following information: \n\n";

        public CreateInterviewMessageHandler(IInterviewRepository interviewRepository,
            IMessageRepository messageRepository,
            IMapper mapper,
            IQueryGeneratorService queryGeneratorService,
            ILLMService llmService,
            ILogger<CreateInterviewMessageHandler> logger)
        {
            _interviewRepository = interviewRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;

            _queryGeneratorService = queryGeneratorService;
            _llmService = llmService;
            _logger = logger;
        }

        public async Task<MessageDTO> Handle(CreateInterviewMessageCommand request, CancellationToken cancellationToken)
        {
            var interview = await _interviewRepository.GetByRefIdAsync(request.InterviewRefId);
            if (interview == null)
                throw new NotFoundException("Interview not found");

            var message = _mapper.Map<Message>(request.MessageDTO);
            message.InterviewId = interview.Id;

            var POCOs = new List<BasePOCO> { interview, interview.Candidate, message };

            var sb = new StringBuilder(MessageSuffix);

            foreach (var poco in POCOs)
            {
                sb.Append(_queryGeneratorService.GenerateQueryFromPOCO(poco));
                sb.Append("\n");
            }

            message.Query = sb.ToString();

            _logger.LogInformation($"Sending query to LLM: {message.Query}");

            message.Response = await _llmService.SendQueryAsync(message.Query);

            _logger.LogInformation($"LLM response: {message.Response}");

            await _messageRepository.CreateAsync(message);

            return _mapper.Map<MessageDTO>(message);
        }
    }
}
