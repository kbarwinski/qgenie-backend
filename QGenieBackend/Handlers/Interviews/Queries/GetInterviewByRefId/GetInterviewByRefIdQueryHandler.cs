using AutoMapper;
using MediatR;
using QGenieBackend.Handlers.Interviews.DTOs;
using QGenieBackend.Repositories.Interviews;

namespace QGenieBackend.Handlers.Interviews.Queries.GetInterviewByRefId
{
    public class GetInterviewByRefIdQueryHandler : IRequestHandler<GetInterviewByRefIdQuery, InterviewDTO>
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;

        public GetInterviewByRefIdQueryHandler(IInterviewRepository interviewRepository, IMapper mapper)
        {
            _interviewRepository = interviewRepository;
            _mapper = mapper;
        }

        public async Task<InterviewDTO> Handle(GetInterviewByRefIdQuery request, CancellationToken cancellationToken)
        {
            var interview = await _interviewRepository.GetByRefIdAsync(request.RefId);

            return _mapper.Map<InterviewDTO>(interview);
        }
    }
}
