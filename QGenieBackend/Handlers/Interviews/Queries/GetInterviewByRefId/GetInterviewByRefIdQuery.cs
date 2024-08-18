using MediatR;
using QGenieBackend.Handlers.Interviews.DTOs;

namespace QGenieBackend.Handlers.Interviews.Queries.GetInterviewByRefId
{
    public class GetInterviewByRefIdQuery : IRequest<InterviewDTO>
    {
        public int RefId { get; set; }
    }
}
