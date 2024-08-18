using QGenieBackend.Types;

namespace QGenieBackend.POCOs
{
    public class Candidate : BasePOCO
    {
        public CredentialsQueryPart Credentials { get; set; }
        public Interview Interview { get; set; }
    }
}
