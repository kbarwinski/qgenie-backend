using MongoDB.Bson;
using MongoDB.Driver;
using QGenieBackend.Contexts;
using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Base;

namespace QGenieBackend.Repositories.Interviews
{
    public class InterviewRepository : BaseRepository<Interview>, IInterviewRepository
    {
        public InterviewRepository(MongoDbContext context) : base(context, ctx => ctx.Interviews) { }

        public async Task<Interview> GetByRefIdAsync(int refId)
        {
            var result = await _mainCollection.Aggregate()
                .Match(e => e.RefId == refId)
                .Lookup("Candidates", "CandidateId", "_id", @as: "Candidate")
                .Unwind("Candidate")
                .As<Interview>()
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
