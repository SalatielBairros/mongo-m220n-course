using MongoDB.Driver;

namespace M220N.Console
{
    public class MongoRepository
    {
        private readonly string ConnectionString;
        public MongoRepository(string conn)
        {
            ConnectionString = conn;
        }

        public void CreateConnection()
        {
            var settings = MongoClientSettings.FromConnectionString(ConnectionString);
            var client = new MongoClient(settings);
            var db = client.GetDatabase("sample_mflix");
        }
    }
}
