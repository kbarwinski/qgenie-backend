using QGenieBackend.Handlers.Candidates.DTOs;

namespace QGenieBackend.Handlers.Interviews.DTOs
{
    public class InterviewCreationDTO
    {
        public int RefId { get; set; }
        public Guid InterviewerGuid { get; set; }

        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
    }
}
