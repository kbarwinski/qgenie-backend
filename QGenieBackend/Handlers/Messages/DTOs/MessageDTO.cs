using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using QGenieBackend.Types;

namespace QGenieBackend.Handlers.Messages.DTOs
{
    public class MessageDTO
    {
        public Guid Id { get; set; }
        public int InterviewRefId { get; set; }

        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobSeniority { get; set; }

        public string CandidateCredentials { get; set; }

        public string InterviewCharacter { get; set; }
        public string Notes { get; set; }
        public string Response { get; set; }
    }
}
