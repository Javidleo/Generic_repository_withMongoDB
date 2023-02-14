using MongoDB.Driver;

namespace MongoApi.Context
{
    public interface IMongoContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
