using MongoDB.Driver;

namespace Data.Mongo
{
    public class MongoDemoContext : IMongoBaseContext
    {
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public MongoDemoContext()
        {
            Client = new MongoClient(AppSettings.MongoSettings.ConnectionString);
            Database = Client.GetDatabase(AppSettings.MongoSettings.DatabaseName);
        }
    }
}