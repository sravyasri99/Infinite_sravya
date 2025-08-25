using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CodeFirst.Models;
using MVC_CodeFirst.Repository;

namespace MVC_CodeFirst.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository = new MovieRepository();

        public ActionResult Index()
        {
            var movies = movieRepository.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Create(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = movieRepository.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Edit(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = movieRepository.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = movieRepository.GetAllMoviesByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = movieRepository.GetMoviesByDirector(directorName);
            return View(movies);
        }
    }
}
