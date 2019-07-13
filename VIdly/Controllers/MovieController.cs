using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIdly.Models;

namespace VIdly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movies = GetMovie();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = GetMovie().SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }

        private IEnumerable<Movie> GetMovie()
        {
            return new List<Movie>
            {
                new Movie{Name = "Rang De Basanti", Id = 1},
                new Movie{Name = "Legend Of Bhagat Singh", Id = 2}
            };
        }
    }
}