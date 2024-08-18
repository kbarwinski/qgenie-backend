namespace QGenieBackend.Types
{
    public class JobTitleQueryPart : QueryPart
    {
        protected override string Query => "Job title: ${PLACEHOLDER}";
    }

    public class JobDescriptionQueryPart : QueryPart
    {
        protected override string Query => "Job description:\n\"${PLACEHOLDER}\"";
    }
}
