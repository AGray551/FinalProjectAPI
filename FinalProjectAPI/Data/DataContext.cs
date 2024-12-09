using Microsoft.EntityFrameworkCore;
using FinalProjectAPI.Entities;

namespace FinalProjectAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<SuperHero> SuperHeroes {  get; set; }
        public DbSet<Student> Students { get; set; }   
        public DbSet<Cat> Cats { get; set; }

    }
}
