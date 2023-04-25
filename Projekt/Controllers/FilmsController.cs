using Microsoft.AspNetCore.Mvc;
using Projekt.Models.Films;
using Projekt.Services.Film;

namespace Projekt.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService _filmService;
        public FilmsController(ILogger<FilmsController> logger, IFilmService filmService)
        {
            _filmService = filmService;
        }

        public IActionResult Index()
        {
            var model = new FilmsViewModel()
            {
                Films = _filmService.GetFilms()
            };
            return View(model);
        }

        public IActionResult InsertNewFilm()
        {
            return View();
        }

        public IActionResult InsertFilm(string Title, string Desc, string Director, int YearOfProduction)
        {
            if(string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Desc) && string.IsNullOrEmpty(Director) && YearOfProduction == 0)
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _filmService.InsertFilm(Title, Desc, Director, YearOfProduction);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFilm()
        {
            var model = new FilmsViewModel()
            {
                Films = _filmService.GetFilms()
            };
            return View(model);
        }


        public IActionResult DeleteThisFilm(int id)
        {
            if(id!=0)
            {
                _filmService.DeleteFilm(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }


        public IActionResult UpDateFilm()
        {
            var model = new FilmsViewModel()
            {
                Films = _filmService.GetFilms()
            };
            return View(model);
        }

        public IActionResult UpDateThisFilm(int id, string Title, string Desc, string Director, int YearOfProduction)
        {
            var items = _filmService.GetFilms().Count();
            if (id != 0 && Title != "" && Desc != "" && Director != "" && YearOfProduction != 0)
            {
                _filmService.UpDateFilm(id, Title, Desc, Director, YearOfProduction);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}