using Projekt.Models.Films;

namespace Projekt.Services.Film
{
    public interface IFilmService
    {
        public List<FilmsModel> GetFilms();
        public FilmsModel GetFilms(int id);
        public void InsertFilm(string Title, string Desc, string Director, int YearOfProduction);
        public void UpDateFilm(int id, string Title, string Desc, string Director, int YearOfProduction);
        public void DeleteFilm(int id);
    }
}
