using FinalAPI.Entities;
using FinalAPI.Extensions;
using FinalAPI.Models;
using FinalAPI.Repositories;

namespace FinalAPI.Services
{
    public class ApartamenteService: IApartamenteService
    {
        private readonly IApartamenteRepository _repoA;
        private readonly IUserRepository _repoU;

        public ApartamenteService(IApartamenteRepository repo, IUserRepository repoU)
        {
            _repoA = repo;
            _repoU = repoU;
        }

        public  async Task<Apartament?> CreateAsync(ApartamentDTO apartament)
        {
            var user = await _repoU.FindOneAsync(u => u.ID_User == apartament.ID_Proprietar);
            if(user == null)
                return null;
            
            var appEntity = apartament.ToEntity();
            appEntity.Proprietar = user;
            return await _repoA.CreateAsync(appEntity);
        }

        public async Task<Apartament?> DeleteAsync(long id)
        {
            return await _repoA.DeleteAsync(id);
        }

        public async Task<IEnumerable<Apartament>> GetAllWithUserAsync()
        {
            return await _repoA.GetAllWithUserAsync();
        }

        public async Task<Apartament?> UpdateAsync(ApartamentDTO apartament)
        {
            var user = await _repoU.FindOneAsync(u => u.ID_User == apartament.ID_Proprietar);
            if(user == null)
                return null;
            var appEntity = apartament.ToEntity();
            appEntity.Proprietar = user;
            return await _repoA.UpdateAsync(appEntity);
        }
    }
}
