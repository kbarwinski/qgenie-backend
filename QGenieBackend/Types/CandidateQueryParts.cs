namespace QGenieBackend.Types
{
    public class CredentialsQueryPart : QueryPart
    {
        protected override string Query => "Interviewed candidate: ${PLACEHOLDER}";
    }
}
