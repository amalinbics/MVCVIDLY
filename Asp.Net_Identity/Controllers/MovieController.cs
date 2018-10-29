using Asp.Net_Identity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.Net_Identity.Models;
namespace Asp.Net_Identity.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            if (User.IsInRole(ApplicationConstant.Roles.CanManageMovie))
                return View("ManageMovies");

            return View("ListMovies");
        }

        [Authorize(Roles = ApplicationConstant.Roles.CanManageMovie)]
        public ActionResult New()
        {
            var movieViewModel = new MovieViewModel
            {
                Id = 0,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieViewModel = new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                NoInStock = movie.NoInStock,
                ReleaseDate = movie.ReleaseDate,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = ApplicationConstant.Roles.CanManageMovie)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Id = movie.Id,
                    GenreId = movie.GenreId,
                    Name = movie.Name,
                    ReleaseDate = movie.ReleaseDate,
                    NoInStock = movie.NoInStock,
                    Genres = _context.Genres.ToList()
                };
                return View(viewModel);
            }
            else
            {
                if (movie.Id == 0)
                {
                    _context.Movies.Add(movie);
                }                    
                else
                {
                    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NoInStock = movie.NoInStock;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }



    }
}