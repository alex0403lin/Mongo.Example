using System.Linq.Expressions;
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
            _collection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual TEntity GetById(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefault();
        }

        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }
        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _collection.Find(e => true).ToListAsync();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual void InsertMany(IEnumerable<TEntity> entities)
        {
            _collection.InsertMany(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities)
        {
            await _collection.InsertManyAsync(entities);
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _collection.ReplaceOne(x => x.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = false });
            return entity; ;
        }

        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Update(entity);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                await UpdateAsync(entity);
            }
            return entities;
        }

        public virtual void Delete(TEntity entity)
        {
            _collection.FindOneAndDelete(e => e.Id == entity.Id);
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await _collection.DeleteOneAsync(e => e.Id == entity.Id);
            return entity;
        }

        public virtual void DeleteMany(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _collection.FindOneAndDelete(e => e.Id == entity.Id);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                await DeleteAsync(entity);
            }
            return entities;
        }
    }
}