using Microsoft.Extensions.DependencyInjection;
using SharedFrameWork.Application;
using SharedFrameWork.Infrastructure;

namespace SharedFrameWork
{
    public static class SHAREDFRAMEWORKDI
    {
        public static void RegisterSharedFrameworkService(this IServiceCollection services,string connectionString)
        {
            services.AddScoped<IMongoDbHelper>(x => new MongoDbHelper(connectionString));

        }
    }
}
