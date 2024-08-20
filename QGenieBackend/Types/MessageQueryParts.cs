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

    public class JobSeniorityQueryPart : QueryPart
    {
        protected override string Query => "Job seniority level: ${PLACEHOLDER}";
    }

    public class InterviewCharacterQueryPart : QueryPart
    {
        protected override string Query => "Character of the interview: ${PLACEHOLDER}";
    }

    public class NotesQueryPart : QueryPart
    {
        protected override string Query => "Additional notes:\n${PLACEHOLDER}";
        public override int Precedence { get; } = 1;
    }
}
