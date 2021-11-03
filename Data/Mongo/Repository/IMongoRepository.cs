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
    }
}