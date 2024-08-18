using QGenieBackend.Contexts;
using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Base;

namespace QGenieBackend.Repositories.Candidates
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(MongoDbContext context) : base(context, ctx => ctx.Candidates) { }

        // Implement any Candidate-specific methods here
    }
}
