using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using QGenieBackend.Types;

namespace QGenieBackend.POCOs
{
    public class Message : BasePOCO
    {
        public InterviewCharacterQueryPart InterviewCharacter { get; set; }
        public JobSeniorityQueryPart JobSeniority { get; set; }
        public NotesQueryPart Notes { get; set; }
        public string Query { get; set; }
        public string Response { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid InterviewId { get; set; }
    }
}
