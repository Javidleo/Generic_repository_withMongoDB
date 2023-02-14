using Microsoft.Extensions.Options;
using MongoApi.Domain;
using MongoDB.Driver;
namespace MongoApi.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _client { get; set; }
        private IClientSessionHandle Session { get; set; }
        private readonly IOptions<MongoSettings> _settings;
        public MongoContext() { }

        public MongoContext(IOptions<MongoSettings> settings)
        {
            _settings = settings;
            _client = new MongoClient(_settings.Value.ConnectionString);
            _db = _client.GetDatabase(_settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        => _db.GetCollection<T>(collectionName);


        public IMongoCollection<User> Users { get; set; }
        public IMongoCollection<Book> Books { get; set; }
    }
}
