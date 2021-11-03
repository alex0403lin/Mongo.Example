using Data.Models;
using MongoDB.Driver;

namespace Data.Mongo.Repository
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : BaseModel
    {
        protected IMongoCollection<TEntity> _collection;
        private IMongoContext _context;

        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _collection;
            }
        }

        public MongoRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public TEntity GetById(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefault();
        }

        public Task<TEntity> GetByIdAsync(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
           return _collection.Find(e => true).ToListAsync();
        }
    }
}