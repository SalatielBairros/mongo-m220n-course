using System.Collections.Generic;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;

namespace M220N.Console
{
    public class MongoRepository
    {
        private readonly string _connectionString;
        public MongoRepository(string conn)
        {
            _connectionString = conn;
        }

        public IMongoDatabase CreateConnection(string database)
        {
            var settings = MongoClientSettings.FromConnectionString(_connectionString);
            var client = new MongoClient(settings);
            return client.GetDatabase(database);
        }

        public BsonDocument GetFirst(string collectionName, object filter)
        {
            var conn = CreateConnection("sample_mflix");
            var collection = conn.GetCollection<BsonDocument>(collectionName);

            return (filter != null
                ? collection.Find(JsonSerializer.Serialize(filter))
                : collection.Find("{}")).FirstOrDefault();
        }

        public List<BsonDocument> GetAll(string collectionName, int page, int pageSize, string sortedBy){
            var conn = CreateConnection("sample_mflix");
            var collection = conn.GetCollection<BsonDocument>(collectionName);

            return collection
                .Find(new BsonDocument())
                .SortByDescending(i => i[sortedBy])
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToList();
        }
    }
}
