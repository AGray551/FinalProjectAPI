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
    public class StudentController : Controller
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetStudent(int id)
        {
            var hero = await _context.Students.FindAsync(id);
            if (hero == null)
                return BadRequest("Student not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student updatedStudent)
        {
            var dbStudent = await _context.Students.FindAsync(updatedStudent.Id);
            if (dbStudent == null)
                return NotFound("Student not found");

            dbStudent.Name = updatedStudent.Name;
            dbStudent.Birthday = updatedStudent.Birthday;
            dbStudent.CollegeProgram = updatedStudent.CollegeProgram;
            dbStudent.Year = updatedStudent.Year;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null)
                return NotFound("Student not found");

            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}