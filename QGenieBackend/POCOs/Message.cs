using QGenieBackend.Types;

namespace QGenieBackend.POCOs
{
    public class Message : BasePOCO
    {
        public int InterviewRefId { get; set; }

        public JobTitleQueryPart JobTitle { get; set; }
        public JobDescriptionQueryPart JobDescription { get; set; }
        public JobSeniorityQueryPart JobSeniority { get; set; }

        public InterviewCharacterQueryPart InterviewCharacter { get; set; }
        public NotesQueryPart Notes { get; set; }

        public string Query { get; set; }
        public string Response { get; set; }
    }
}
