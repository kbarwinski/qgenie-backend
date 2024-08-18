using MongoDB.Driver;
using QGenieBackend.Contexts;
using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Base;

namespace QGenieBackend.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(MongoDbContext context) : base(context, ctx => ctx.Messages) { }

        public async Task<Message> GetLastMessageByInterviewRefIdAsync(int refId)
        {
            return await _mainCollection
                .Find(m => m.InterviewRefId == refId)
                .SortByDescending(m => m.DateCreated)
                .FirstOrDefaultAsync();
        }
    }
}
