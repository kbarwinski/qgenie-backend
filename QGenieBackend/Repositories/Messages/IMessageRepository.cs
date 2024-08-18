using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Base;

namespace QGenieBackend.Repositories.Messages
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesByInterviewIdAsync(Guid interviewId);
    }
}
