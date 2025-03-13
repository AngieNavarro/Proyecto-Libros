using Microsoft.EntityFrameworkCore;
using ProyectoLibros.Components.Modelos;

namespace ProyectoLibros.Components.Clases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //colocamos cada uno de los modelos
        public DbSet<Libro> Libros { get; set; } 
    }
}
