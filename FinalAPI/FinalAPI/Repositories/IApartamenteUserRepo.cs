using FinalAPI.Entities;

namespace FinalAPI.Repositories
{
    public interface IApartamenteUserRepo: IRepository<Apartament_User>
    {
        public Task<IEnumerable<Apartament_User>> GetCompleteRowAsync();
        public Task<IEnumerable<Apartament_User>> GetCompleteRowByUserAsync(long id);

    }
}
