using MongoDB.Driver;

namespace Data.Mongo
{
    public interface IMongoBaseContext
    {
        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
    }
}

