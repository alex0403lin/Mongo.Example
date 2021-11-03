namespace Data.Mongo
{
    public class MongoProvider : IMongoProvider
    {
        public MongoProvider()
        {
        }

        public string ConnectionString => AppSettings.MongoSettings.ConnectionString;

        public string DatabaseName => AppSettings.MongoSettings.DatabaseName;
    }
}