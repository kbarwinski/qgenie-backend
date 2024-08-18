using QGenieBackend.POCOs;

namespace QGenieBackend.Repositories.Base
{
    public interface IBaseRepository<T> where T : BasePOCO
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
