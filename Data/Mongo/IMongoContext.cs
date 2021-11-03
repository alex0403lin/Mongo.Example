using MongoDB.Driver;

namespace Data.Mongo
{
    public interface IMongoContext
    {
        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
    }
}

