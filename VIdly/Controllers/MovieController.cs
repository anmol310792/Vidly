using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIdly.Models;
using System.Data.Entity;
using VIdly.ViewModels;
using System.Data.Entity.Validation;

namespace VIdly.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MovieController()
        {
            _context = new ApplicationDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModle = new MovieFormViewModel
            {
                Genres = genre,
                Movies = new Movie()
            };
            return View("MovieForm", viewModle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var movieModel = new MovieFormViewModel
                {
                    Movies = viewModel.Movies,
                    Genres = _context.Genres.ToList()
                };
                return View ("MovieForm", movieModel);
            }
            if (viewModel.Movies.Id == 0)
                _context.Movies.Add(viewModel.Movies);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Movies.Id);

                movieInDb.Name = viewModel.Movies.Name;
                movieInDb.ReleaseDate = viewModel.Movies.ReleaseDate;
                movieInDb.Genre = viewModel.Movies.Genre;
                movieInDb.NumberinStock = viewModel.Movies.NumberinStock;
            }
            
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movies = movie,
                Genres = _context.Genres
            };

            return View("MovieForm",viewModel);
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }
    }
}