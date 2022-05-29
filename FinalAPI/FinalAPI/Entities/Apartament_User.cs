using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAPI.Entities
{
    public class Apartament_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? ID_Apartament_User { get; set; }
        [ForeignKey("Apartament")]
        public long ID_Apartament {get; set;}
        [Required]
        public Apartament Apartament {get; set;} = null!;
        [ForeignKey("User")]
        public long ID_User {get; set;}
        [Required]
        public User Locatar {get; set;} = null!;
        public DateTime StartTime {get;set;}
        public DateTime? EndTIme {get;set;}
    }
}
