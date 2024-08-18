using QGenieBackend.Handlers.Candidates.DTOs;

namespace QGenieBackend.Handlers.Interviews.DTOs
{
    public class InterviewDTO
    {
        public Guid Id { get; set; }
        public int RefId { get; set; }
        public Guid InterviewerGuid { get; set; }

        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        public CandidateDTO Candidate { get; set; }
    }
}
