using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FinalAPI.Entities
{
    public class Apartament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? ID_Apartament { get; set; }
        [Required]
        public string Adresa { get; set; } = null!;
        [Required]
        public ulong Chirie { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User Proprietar {get; set;} = null!;

    }
}
