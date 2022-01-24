using MongoDB.Driver;
using SharedFrameWork.Application;

namespace SharedFrameWork.Infrastructure
{
   public class MongoDbHelper:IMongoDbHelper
    {
        private MongoUrl uri;
        private MongoClient _client;
        private static object _locker = new();


        public MongoDbHelper(string connectionstring)
        {
            uri = new MongoUrl(connectionstring);
        }


        public MongoClient Create()
        {
            lock (_locker)
            {
                if (_client == null)
                    _client = new MongoClient();


                return _client;
            }
        }
    }
}
