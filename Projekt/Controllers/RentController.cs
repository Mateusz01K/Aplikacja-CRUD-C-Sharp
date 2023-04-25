using Microsoft.AspNetCore.Mvc;
using Projekt.Models.Films;
using Projekt.Models.Rents;
using Projekt.Models.Users;
using Projekt.Services.Film;
using Projekt.Services.Rent;
using Projekt.Services.User;
using System.IO;

namespace Projekt.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IFilmService _filmService;
        private readonly IUserService _userService;



        public RentController(IRentService rentService, IFilmService filmService, IUserService userService)
        {
            _rentService = rentService;
            _filmService = filmService;
            _userService = userService;
        }


        public IActionResult Index()
        {
            var model = new RentViewModel()
            {
                Rents = _rentService.GetRents(),
                Films = _filmService.GetFilms(),
                Users = _userService.GetUsers()
            };
            return View(model);
        }


        public IActionResult RentFilms()
        {
            var model = new RentViewModel()
            {
                Rents = _rentService.GetRents(),
                Films = _filmService.GetFilms(),
                Users = _userService.GetUsers()
            };
            return View(model);
        }
        
        public IActionResult RentThisFilm(int filmId, int userId)
        {
            if (filmId != 0 && userId != 0)
            {
                _rentService.RentFilm(filmId, userId);
                return RedirectToAction("Index");
            }

        TempData["message"] = "Popraw dane.";
        return RedirectToAction("Index");
        }

        public IActionResult DeleteRent()
        {
            var model = new RentViewModel()
            {
                Rents = _rentService.GetRents(),
                Films = _filmService.GetFilms(),
                Users = _userService.GetUsers()
            };
            return View(model);
        }

        public IActionResult DeleteThisRent(int id)
        {
            var items = _rentService.GetRents().Count();
            if(id != 0)
            {
                _rentService.DeleteRent(id);
                return RedirectToAction("Index");
            }

        TempData["message"] = "Popraw dane.";
        return RedirectToAction("Index");
        }

        public IActionResult ReturnRent()
        {
            var model = new RentViewModel()
            {
                Rents = _rentService.GetRents(),
                Films = _filmService.GetFilms(),
                Users = _userService.GetUsers()
            };

            return View(model);
        }

        public IActionResult ReturnThisRent(int id)
        {
            if (id != 0 )
            {
                _rentService.ReturnRent(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
