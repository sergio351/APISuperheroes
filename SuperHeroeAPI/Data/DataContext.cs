using Microsoft.EntityFrameworkCore;
using SuperHeroeAPI.Models;

namespace SuperHeroeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<SuperHeroe> Superheroes { get; set; } //nombre tabla base de datos
        
    }
}
    

