using FinalAPI.DbContexts;
using FinalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalAPI.Repositories
{
    public class ApartamenteRepository: Repository<Apartament>, IApartamenteRepository
    {
        private readonly Database _db;
        public ApartamenteRepository(Database database, ILogger<ApartamenteRepository> logger): base(database, logger)
        {
            _db = database;
        }

        public async Task<IEnumerable<Apartament>> GetAllWithUserAsync()
        {
            return await _db.Apartamentes.Include(a => a.Proprietar).ToArrayAsync();
        }
    }
}
