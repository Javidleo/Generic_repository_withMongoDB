using MongoApi.Repository.Abstraction;
using MongoApi.Domain;

namespace MongoApi.Repository.User
{
    public interface IUserRepository : IBaseRepository<Domain.User>
    {

    }
}
