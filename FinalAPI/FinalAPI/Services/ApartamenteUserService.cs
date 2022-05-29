using FinalAPI.Entities;
using FinalAPI.Extensions;
using FinalAPI.Models;
using FinalAPI.Repositories;
using System.Linq;

namespace FinalAPI.Services
{
    public class ApartamenteUserService: IApartamenteUserService
    {
        private readonly IApartamenteRepository _apprepo;
        private readonly IUserRepository _userrepo;
        private readonly IApartamenteUserRepo _appuserrepo;


        public ApartamenteUserService(IApartamenteRepository apprepo, IUserRepository userrepo, IApartamenteUserRepo aurepo)
        {
            _apprepo = apprepo;
            _userrepo = userrepo;
            _appuserrepo = aurepo;
        }

        public async Task<IList<ApartamentComplet?>> GetApartamentCompletAllAsync()
        {
            List<ApartamentComplet?> result = new();
            foreach(var app in await _appuserrepo.FindAllAsync(e => true))
            {
                ApartamentComplet complet = new();
                complet.ID_Apartament_User = app.ID_Apartament_User;
                await Task.WhenAll(new List<Task>(){
                    SetApartamentAsync(app.ID_Apartament, complet),
                    SetLocatariAsync(app.ID_User, complet)
                });

                result.Add(complet);
            }
            return result;
        }

        public async Task<Apartament_User> AddUserToApartament(ApartamentUserAddRequest request)
        {
            var user = await _appuserrepo.CreateAsync(request.toEntity());
            user.Locatar = await _userrepo.FindOneAsync(u => u.ID_User == user.ID_User);
            user.Apartament = await _apprepo.FindOneAsync(a => a.ID_Apartament == user.ID_Apartament);
            return user;
        }

        // todo 
        public Task<ApartamentComplet?> GetApartamentCompletByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        private async Task SetApartamentAsync(long id, ApartamentComplet complet)
        {
            await Task.Run(async() =>
            {
                var entity = await _apprepo.FindOneAsync(a => a.ID_Apartament == id);
                complet.Adresa = entity.Adresa;
                complet.Chirie = entity.Chirie;
                complet.ID_Apartament = entity.ID_Apartament;
            });
        }

        private async Task SetLocatariAsync(long id, ApartamentComplet complet)
        {
            await Task.Run(async() =>
            {
                var locatari = await _appuserrepo.GetCompleteRowByUserAsync(id);
                complet.Locatari = locatari.Select(au => au.Locatar.ToDTO()).ToList();
            });
        }
    }
}
