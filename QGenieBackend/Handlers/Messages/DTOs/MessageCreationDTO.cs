namespace QGenieBackend.Handlers.Messages.DTOs
{
    public class MessageCreationDTO
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobSeniority { get; set; }

        public string CandidateCredentials { get; set; }

        public string InterviewCharacter { get; set; }
        public string Notes { get; set; }
    }
}
