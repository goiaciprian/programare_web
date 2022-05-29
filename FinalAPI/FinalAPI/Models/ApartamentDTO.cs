using System.ComponentModel.DataAnnotations;

namespace FinalAPI.Models
{
    public class ApartamentDTO
    {
        public long? ID_Apartament { get; set; }
        [Required]
        public string Adresa { get; set; } = null!;
        [Required]
        public ulong Chirie { get; set; }
        public long ID_Proprietar {get; set;}
    }
}
