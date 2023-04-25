using Projekt.Models.Users;
using Projekt.Models.Films;
using Projekt.Models.Rents;

namespace Projekt.Services.Rent
{
    public interface IRentService
    {
        public void RentFilm(int filmId, int userId);
        public RentsModel GetRents(int id);
        public List<RentsModel> GetRents();

        public void DeleteRent(int id);
        public void ReturnRent(int id);
        
    }
}