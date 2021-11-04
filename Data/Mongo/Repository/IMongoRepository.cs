using System.Linq.Expressions;
using Data.Models;
using MongoDB.Driver;

namespace Data.Mongo.Repository
{
    public interface IMongoRepository<TEntity> where TEntity : BaseModel
    {
        IMongoCollection<TEntity> Collection { get; }
        TEntity GetById(string id);
        Task<TEntity> GetByIdAsync(string id);
        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        void InsertMany(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> DeleteManyAsync(IEnumerable<TEntity> entities);

    }
}