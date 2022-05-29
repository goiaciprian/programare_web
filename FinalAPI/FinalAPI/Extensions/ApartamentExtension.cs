using FinalAPI.Entities;
using FinalAPI.Models;

namespace FinalAPI.Extensions
{
    public static class ApartamentExtension
    {
        public static ApartamentDTO ToDTO(this Apartament app)
        {
            return new ApartamentDTO()
            {
                ID_Proprietar = app.Proprietar.ID_User ?? -1,
                Adresa = app.Adresa,
                Chirie = app.Chirie,
                ID_Apartament = app.ID_Apartament
            };
        }

        public static Apartament ToEntity(this ApartamentDTO app)
        {
            return new Apartament()
            {
                Adresa = app.Adresa,
                Chirie = app.Chirie,
                ID_Apartament = app.ID_Apartament
            };
        }
    }
}
