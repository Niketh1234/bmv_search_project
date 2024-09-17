using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SearchService.Models
{
    public class ServiceDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string SearchCollectionName { get; set; } = null!;
    }
    public class Searchable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int VenueId {  get; set; }
        public string VenueName {  get; set; }
        public string VenueDescription { get; set; }
        public string VenueCategory { get; set; }
        public string ProviderName { get; set; }
        public string City {  get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
