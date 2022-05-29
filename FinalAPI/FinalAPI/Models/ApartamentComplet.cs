namespace FinalAPI.Models
{
    public class ApartamentComplet
    {
        public long? ID_Apartament_User { get; set; }
        public long? ID_Apartament { get; set; }
        public string Adresa { get; set; } = null!;
        public ulong Chirie { get; set; }
        public IList<UserDTO> Locatari {get; set; } = new List<UserDTO>();
    }
}
