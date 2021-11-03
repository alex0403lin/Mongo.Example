using MongoDB.Driver;

namespace Data.Mongo
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoProvider _provider;
        public MongoContext(
            IMongoProvider provider
        )
        {
            _provider = provider;
        }

        public IMongoClient Client => new MongoClient(_provider.ConnectionString);

        public IMongoDatabase Database => this.Client.GetDatabase(_provider.DatabaseName);
    }
}