namespace FinalAPI.Models
{
    public class ApartamentUserAddRequest
    {
        public long ID_Apartament {get; set;}
        public long ID_User {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime? EndDate {get; set;}
    }
}
