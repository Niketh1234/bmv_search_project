using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using SearchService.Models;

namespace SearchService.Services
{
    public class SearchableService
    {
        private readonly IMongoCollection<Searchable> _searchablesCollection;

        public SearchableService(
            IOptions<ServiceDbSettings> serviceDbSettings)
        {
            var mongoClient = new MongoClient(
                serviceDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                serviceDbSettings.Value.DatabaseName);

            _searchablesCollection = mongoDatabase.GetCollection<Searchable>(
                serviceDbSettings.Value.SearchCollectionName);
        }

        public List<Searchable> Get(string query)
        {
            var filter = Builders<Searchable>.Filter.Or(
             Builders<Searchable>.Filter.Regex("VenueName", new BsonRegularExpression(query, "i")),
             Builders<Searchable>.Filter.Regex("VenueDescription", new BsonRegularExpression(query, "i")),
             Builders<Searchable>.Filter.Regex("VenueCategory", new BsonRegularExpression(query, "i")),
             Builders<Searchable>.Filter.Regex("City", new BsonRegularExpression(query, "i"))
         );
            return _searchablesCollection.Find(filter).ToList().Take(10).ToList();
        }

        public Searchable Add(Searchable newSearchable)
        {
            _searchablesCollection.InsertOne(newSearchable);
            return newSearchable;
        }

    }
}
