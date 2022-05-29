using FinalAPI.Entities;
using FinalAPI.Models;

namespace FinalAPI.Extensions
{
    public static class ApartamentUserExtension
    {
        public static Apartament_User toEntity(this ApartamentUserAddRequest req)
        {
            return new Apartament_User()
            {
                ID_Apartament = req.ID_Apartament,
                ID_User = req.ID_User,
                StartTime = req.StartDate,
                EndTIme = req.EndDate
            };
        }
    }
}
