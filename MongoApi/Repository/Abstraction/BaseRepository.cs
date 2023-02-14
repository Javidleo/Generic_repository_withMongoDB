using MongoApi.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoApi.Repository.Abstraction
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoContext _context;
        private IMongoCollection<T> _collection;

        public BaseRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name);
            // for DI
            GetName = typeof(T).Name;
        }

        public string GetName { get; }

        public async Task<T> Get(string Id)
        {
            var objectId = new ObjectId(Id);

            var filter = Builders<T>.Filter.Eq("_id", objectId);

            return await _collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            var all = await _collection.FindAsync(Builders<T>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Add(List<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }


        public virtual void Update(T entity)
        {
            Type t = entity.GetType();
            var propertyInfo = t.GetProperty("_id");
            _collection.ReplaceOne(Builders<T>.Filter.Eq("_id", propertyInfo.GetValue(entity)), entity);
        }

        public void Delete(string id)
        {
            var objectId = new ObjectId(id);
            _collection.DeleteOne(Builders<T>.Filter.Eq("_id", objectId));
        }

    }
}
