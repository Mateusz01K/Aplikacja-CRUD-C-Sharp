using Projekt.Context;
using Projekt.Models.Films;

namespace Projekt.Services.Film
{
    public class FilmService : IFilmService
    {
        private readonly FilmContext _context;
        public FilmService(FilmContext context)
        {
            _context = context;
        }
        public FilmsModel GetFilms(int id)
        {
            var film = _context.Films.FirstOrDefault(x => x.Id == id);
            return film ?? new FilmsModel();
        }

        public List<FilmsModel> GetFilms()
        {
            return _context.Films.ToList();
        }

        public void InsertFilm(string Title, string Desc, string Director, int YearOfProduction)
        {
            var lastID = _context.Films.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (lastID != null)
            {
                _context.Films.Add(new FilmsModel()
                {
                    Id = (int)lastID + 1,
                    Title = Title,
                    Desc = Desc,
                    Director = Director,
                    YearOfProduction = YearOfProduction
                });
                _context.SaveChanges();
            }
        }
        public void UpDateFilm(int id, string Title, string Desc, string Director, int YearOfProduction)
        {
            var film = _context.Films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                film.Title = Title;
                film.Desc = Desc;
                film.Director = Director;
                film.YearOfProduction = YearOfProduction;
                _context.SaveChanges();
            }
        }

        public void DeleteFilm(int id)
        {
            var film = _context.Films.FirstOrDefault(_x => _x.Id == id);
            if (film != null)
            {
                _context.Films.Remove(film);
                _context.SaveChangesAsync();
            }
        }
    }
}
