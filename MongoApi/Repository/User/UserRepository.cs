using MongoApi.Context;
using MongoApi.Repository.Abstraction;

namespace MongoApi.Repository.User
{
    public class UserRepository : BaseRepository<Domain.User>, IUserRepository
    {
        public UserRepository(IMongoContext context) : base(context)
        {
        }


    }
}
