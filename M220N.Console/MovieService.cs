using System.Linq;
using MongoDB.Bson;

namespace M220N.Console
{
    public class MovieService
    {
        private readonly MongoRepository _repository;

        public MovieService(MongoRepository repository)
        {
            _repository = repository;
        }

        public BsonDocument Get(object filter)
        {
            return _repository.GetFirst("movies", filter);
        }

        public BsonDocument Get10thLongestMovie()
        {
            return _repository.GetAll("movies", 1, 10, "runtime").Last();
        }
    }
}
