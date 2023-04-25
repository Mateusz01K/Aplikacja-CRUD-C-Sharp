using Projekt.Models.Films;
using Projekt.Models.Users;

namespace Projekt.Models.Rents
{
    public class RentsModel
    {
        public RentsModel() { }
        public int Id { get; set; }
        public int FilmId { get; set; }
        public FilmsModel Film { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        

    }
}
