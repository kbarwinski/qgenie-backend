using QGenieBackend.POCOs;
using QGenieBackend.Repositories.Base;

namespace QGenieBackend.Repositories.Interviews
{
    public interface IInterviewRepository : IBaseRepository<Interview>
    {
        Task<Interview> GetByRefIdAsync(int refId);
    }
}
