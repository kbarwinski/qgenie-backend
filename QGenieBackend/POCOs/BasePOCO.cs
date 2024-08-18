using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace QGenieBackend.POCOs
{
    public abstract class BasePOCO
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }

        protected BasePOCO()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTimeOffset.UtcNow;
        }
    }
}
