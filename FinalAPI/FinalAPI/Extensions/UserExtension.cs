using FinalAPI.Entities;
using FinalAPI.Models;

namespace FinalAPI.Extensions
{
    public static class UserExtension
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ID_User = user.ID_User,
            };
        }

        public static User ToEntity(this UserDTO user)
        {
            return new User()
            {
                CreatedAt = DateTime.Now,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ID_User = user.ID_User,
            };
        }
    }
}
