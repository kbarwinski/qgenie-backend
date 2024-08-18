namespace QGenieBackend.Types
{
    public class InterviewCharacterQueryPart : QueryPart
    {
        protected override string Query => "Character of the interview: ${PLACEHOLDER}";
    }

    public class JobSeniorityQueryPart : QueryPart
    {
        protected override string Query => "Job seniority level: ${PLACEHOLDER}";
    }

    public class NotesQueryPart : QueryPart
    {
        protected override string Query => "Additional notes:\n${PLACEHOLDER}";
        public override int Precedence { get; } = 1;
    }
}
