using Data.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class AppSettings
    {
        public static MongoSettings MongoSettings { get; set; }

        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            MongoSettings = configuration.GetSection("MongoSettings").Get<MongoSettings>();
        }
    }
}