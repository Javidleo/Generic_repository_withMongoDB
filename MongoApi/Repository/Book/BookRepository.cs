using MongoApi.Context;
using MongoApi.Repository.Abstraction;

namespace MongoApi.Repository.Book
{
    public class BookRepository : BaseRepository<Domain.Book>, IBookRepository
    {
        public BookRepository(IMongoContext context) : base(context)
        {
        }

    }
}
