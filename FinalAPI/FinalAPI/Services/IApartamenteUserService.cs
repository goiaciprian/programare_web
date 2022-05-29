using FinalAPI.Entities;
using FinalAPI.Models;

namespace FinalAPI.Services
{
    public interface IApartamenteUserService
    {
        Task<ApartamentComplet?> GetApartamentCompletByIdAsync(long id);
        Task<IList<ApartamentComplet?>> GetApartamentCompletAllAsync();

        Task<Apartament_User> AddUserToApartament(ApartamentUserAddRequest request);
    }
}
