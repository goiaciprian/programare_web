using FinalAPI.Entities;

namespace FinalAPI.Repositories
{
    public interface IApartamenteRepository: IRepository<Apartament>
    {
        Task<IEnumerable<Apartament>> GetAllWithUserAsync();
    }
}
