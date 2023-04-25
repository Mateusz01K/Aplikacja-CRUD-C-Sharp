using Projekt.Context;
using Projekt.Models.Films;
using Projekt.Models.Rents;

namespace Projekt.Services.Rent
{
    public class RentService : IRentService
    {
        private readonly FilmContext _context;
        public RentService(FilmContext context)
        {
            _context = context;
        }
        public RentsModel GetRents(int id)
        {
            var rent = _context.Rents.FirstOrDefault(x => x.Id == id);
            return rent ?? new RentsModel();
        }

        public List<RentsModel> GetRents()
        {
            return _context.Rents.ToList();
        }

        public void RentFilm(int filmId, int userId)
        {
            var film = _context.Films.FirstOrDefault(x => x.Id == filmId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (film != null && user != null)
            {
                _context.Rents.Add(new RentsModel
                {
                    Film = film,
                    User = user,
                    RentalDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(7)
                });
                _context.SaveChanges();
            }
        }

        public void DeleteRent(int id)
        {
            var rent = _context.Rents.FirstOrDefault(x => x.Id == id);

            if (rent != null)
            {
                _context.Rents.Remove(rent);
                _context.SaveChanges();
            }
        }

        public void ReturnRent(int id)
        {
            var rent = _context.Rents.FirstOrDefault(x => x.Id == id);

            if (rent != null)
            {
                rent.IsReturned = true;
                _context.SaveChanges();
            }

        }
    }
}
