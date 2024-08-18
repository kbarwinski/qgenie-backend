using MongoDB.Driver;
using QGenieBackend.Contexts;
using QGenieBackend.POCOs;

namespace QGenieBackend.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BasePOCO
    {
        protected readonly MongoDbContext _context;
        protected readonly IMongoCollection<T> _mainCollection;

        protected BaseRepository(MongoDbContext context, Func<MongoDbContext, IMongoCollection<T>> collectionSelector)
        {
            _context = context;
            _mainCollection = collectionSelector(context);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _mainCollection.Find(_ => true).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _mainCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _mainCollection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            await _mainCollection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _mainCollection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
