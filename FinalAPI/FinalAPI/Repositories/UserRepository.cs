using FinalAPI.DbContexts;
using FinalAPI.Entities;

namespace FinalAPI.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(Database database, ILogger<UserRepository> logger): base(database, logger)
        {
        }
  
    }
}
