
using MongoDB.Driver;

namespace SharedFrameWork.Application
{
    public interface IMongoDbHelper
    {
        MongoClient Create();
    }
}
