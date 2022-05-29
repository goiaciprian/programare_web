using FinalAPI.Entities;
using FinalAPI.Models;

namespace FinalAPI.Services
{
    public interface IApartamenteService
    {
        Task<Apartament?> CreateAsync(ApartamentDTO apartament); 
        Task<Apartament?> UpdateAsync(ApartamentDTO apartament); 
        Task<Apartament?> DeleteAsync(long id); 
        Task<IEnumerable<Apartament>> GetAllWithUserAsync();
    }
}
