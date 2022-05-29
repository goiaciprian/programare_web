using System.ComponentModel.DataAnnotations;

namespace FinalAPI.Models
{
    public class UserDTO
    {
        public long? ID_User { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
