using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using QGenieBackend.Types;

namespace QGenieBackend.POCOs
{
    public class Interview : BasePOCO
    {
        //Company's interview row original id
        public int RefId { get; set; }

        //Company's user Guid
        public Guid InterviewerGuid { get; set; }

        public JobTitleQueryPart JobTitle { get; set; }
        public JobDescriptionQueryPart JobDescription { get; set; }
        public Candidate Candidate { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid CandidateId { get; set; }
        public List<Message> Messages { get; set; }
    }
}
