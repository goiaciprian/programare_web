using FinalAPI.DbContexts;
using FinalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalAPI.Repositories
{
    public class ApartamenteUserRepository: Repository<Apartament_User>, IApartamenteUserRepo
    {
        private readonly Database _db;
        public ApartamenteUserRepository(Database db, ILogger<ApartamenteUserRepository> logger): base(db, logger)
        {
            _db = db;
        }

        public async Task<IEnumerable<Apartament_User>> GetCompleteRowAsync()
        {
           return await _db.Apartaments_Users.Include(au => au.Locatar).Include(au => au.Apartament).ToListAsync();
        }

        public async Task<IEnumerable<Apartament_User>> GetCompleteRowByUserAsync(long id)
        {
            return await _db.Apartaments_Users.Include(au => au.Locatar).Where(au => au.ID_User == id).ToListAsync();
        }
    }
}
