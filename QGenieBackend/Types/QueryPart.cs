using MongoDB.Bson.Serialization.Attributes;

namespace QGenieBackend.Types
{
    public abstract class QueryPart
    {
        [BsonIgnore]
        protected abstract string Query { get; }

        [BsonIgnore]
        public virtual int Precedence { get; } = 0;

        [BsonElement("value")]
        public string Value { get; set; }

        public virtual string GetQuery()
        {
            return Query.Replace("${PLACEHOLDER}", Value);
        }

        public override string ToString()
        {
            return GetQuery();
        }
    }
}
