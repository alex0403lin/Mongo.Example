namespace Data.Mongo
{
    public interface IMongoProvider
    {
        /// <summary>
        /// Get connetction string
        /// </summary>
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}