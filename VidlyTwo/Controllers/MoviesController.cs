using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using VidlyTwo.ViewModels;

namespace VidlyTwo.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var viewModel = _context.Movie.ToList();//Movie.Include(m => m.Genre ).ToList();
             /*var movie = new Movie() { Name = "Shrek !" };

             var customers = new List<Customer>
             {
                 new Customer{Name = "Customer1"},
                 new Customer{Name = "Customer2"}
             };

             var viewModel = new RandomMovieViewModel
             {
                 Movie = movie,
                 Customers = customers
             };*/
             return View(viewModel);
            
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            Movie movie = new Movie();
            movie.ReleasedDate = DateTime.MinValue;
            movie.DateAdded = DateTime.MinValue;
            var viewModel = new ViewModels.NewMovieViewModel
            {
                Movie = movie,
                Genres = genre
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreId = movie.GenreId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Index()
        {
            /* if (!pageIndex.HasValue)
             {
                 pageIndex = 1;
             }
             if (string.IsNullOrWhiteSpace(sortBy))
                 sortBy = "Name";
            var movies = new List<Movie>
            {
                new Movie{Id = 1, Name = "Shrek" },
                new Movie{Id = 2, Name = "Wall-e" }
            };
            var moviesList = new ListMoviesModel
            {
                Movies = movies
            };
            */
            var viewModel = _context.Movie.Include(c => c.Genre).ToList();
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}