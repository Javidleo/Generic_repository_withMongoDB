namespace MongoApi.Repository.Abstraction
{
    public interface IBaseRepository<T> where T : class
    {
        // for DI
        string GetName { get; }

        Task Add(T obj);
        Task Add(List<T> entities);
        void Update(T obj);
        void Delete(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> Get();

    }
}
