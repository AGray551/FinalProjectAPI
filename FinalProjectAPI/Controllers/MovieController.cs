using Microsoft.AspNetCore.Mvc;
using FinalProjectAPI.Data;
using FinalProjectAPI.Entities;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movies>>> GetAlls()
        {
            var movies = await _context.Movies.ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetMovie(int id)
        {
            var hero = await _context.Movies.FindAsync(id);
            if (hero == null)
                return BadRequest("Movie not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(await _context.Movies.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie updatedMovie)
        {
            var dbMovie = await _context.Movies.FindAsync(updatedMovie.Id);
            if (dbMovie == null)
                return NotFound("Movie not found");

            dbMovie.Name = updatedMovie.Name;
            dbMovie.Release = updatedMovie.Release;
            dbMovie.Genre = updatedMovie.Genre;
            dbMovie.RunTime = updatedMovie.RunTime;

            await _context.SaveChangesAsync();

            return Ok(await _context.Movies.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int id)
        {
            var dbMovie = await _context.Movies.FindAsync(id);
            if (dbMovie == null)
                return NotFound("Movie not found");

            _context.Movies.Remove(dbMovie);
            await _context.SaveChangesAsync();

            return Ok(await _context.Movies.ToListAsync());
        }
    }
}

