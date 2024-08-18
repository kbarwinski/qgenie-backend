using MediatR;
using QGenieBackend.Handlers.Candidates.DTOs;
using QGenieBackend.Handlers.Interviews.DTOs;

namespace QGenieBackend.Handlers.Interviews.Commands.CreateInterview
{
    public class CreateInterviewCommand : IRequest<InterviewDTO>
    {
        public InterviewCreationDTO InterviewDTO { get; set; }
        public CandidateCreationDTO CandidateDTO { get; set; }
    }
}
