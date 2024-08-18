using AutoMapper;
using MediatR;
using QGenieBackend.Handlers.Interviews.DTOs;
using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Candidates;
using QGenieBackend.Repositories.Interviews;

namespace QGenieBackend.Handlers.Interviews.Commands.CreateInterview
{
    public class CreateInterviewCommandHandler : IRequestHandler<CreateInterviewCommand, InterviewDTO>
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CreateInterviewCommandHandler(IInterviewRepository interviewRepository, ICandidateRepository candidateRepository, IMapper mapper)
        {
            _interviewRepository = interviewRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<InterviewDTO> Handle(CreateInterviewCommand request, CancellationToken cancellationToken)
        {
            var candidate = _mapper.Map<Candidate>(request.CandidateDTO);
            await _candidateRepository.CreateAsync(candidate);

            var interview = _mapper.Map<Interview>(request.InterviewDTO);
            interview.CandidateId = candidate.Id;
            await _interviewRepository.CreateAsync(interview);

            return _mapper.Map<InterviewDTO>(interview);
        }
    }
}
