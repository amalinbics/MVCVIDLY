using Asp.Net_Identity.DTO;
using Asp.Net_Identity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Asp.Net_Identity.Controllers.api
{

    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NoInAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
            {
                movies = movies.Where(m => m.Name.Contains(query));
            }

            var movieDto = movies.
                ToList().
                Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            var movieDto = Mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        [Authorize(Roles = ApplicationConstant.Roles.CanManageMovie)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = ApplicationConstant.Roles.CanManageMovie)]
        public IHttpActionResult SaveMoive(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (movieDto.Id == 0)
            {
                var movie = Mapper.Map<Movie>(movieDto);
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movieDto.Id);
                Mapper.Map(movieDto, movieInDb);
            }
            _context.SaveChanges();

            return Ok();
        }

    }
}
