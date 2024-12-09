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
    public class CatController : Controller
    {
        private readonly DataContext _context;

        public CatController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cat>>> GetAllCats()
        {
            var cats = await _context.Cats.ToListAsync();

            return Ok(cats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetCat(int id)
        {
            var hero = await _context.Cats.FindAsync(id);
            if (hero == null)
                return BadRequest("Cat not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cat>>> AddCat(Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cats.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Cat>>> UpdateCat(Cat updatedCat)
        {
            var dbCat = await _context.Cats.FindAsync(updatedCat.Id);
            if (dbCat == null)
                return NotFound("Cat not found");

            dbCat.Name = updatedCat.Name;
            dbCat.Age = updatedCat.Age;
            dbCat.Breed = updatedCat.Breed;
            dbCat.Weight = updatedCat.Weight;

            await _context.SaveChangesAsync();

            return Ok(await _context.Cats.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Cat>>> DeleteCat(int id)
        {
            var dbCat = await _context.Cats.FindAsync(id);
            if (dbCat == null)
                return NotFound("Cat not found");

            _context.Cats.Remove(dbCat);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cats.ToListAsync());
        }
    }
}