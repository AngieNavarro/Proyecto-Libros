using Microsoft.EntityFrameworkCore;
using ProyectoLibros.Components.Clases;
using ProyectoLibros.Components.Modelos;

namespace ProyectoLibros.Components.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public Repositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;            
        }
        public async Task<Libro> ActualizarLibro(int libroid, Libro actLibro)
        {
            var libroDesdeBd= await _appDbContext.Libros.FindAsync(libroid);
            libroDesdeBd.Titulo=actLibro.Titulo;
            libroDesdeBd.Descripcion=actLibro.Descripcion;
            libroDesdeBd.Autor =actLibro.Autor;
            libroDesdeBd.Paginas = actLibro.Paginas;
            libroDesdeBd.Precio=actLibro.Precio;

            await _appDbContext.SaveChangesAsync();

            return libroDesdeBd;

        }

        public async Task<Libro> CrearLibro(Libro crearLibro)
        {
           if (crearLibro != null)
            {
                crearLibro.FechaCreacion=DateTime.Now;
                await _appDbContext.Libros.AddAsync(crearLibro);
                await _appDbContext.SaveChangesAsync();
                return crearLibro;
            }
            else
            {
                return new Libro();
            }
        }

        public async Task EliminarLibro(int libroid)
        {
            var librodesedb = await _appDbContext.Libros.FindAsync(libroid);
            _appDbContext.Remove(librodesedb);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Libro> GetLibroId(int libroid)
        {
            var librodesedb = await _appDbContext.Libros.FindAsync(libroid);
            if (librodesedb == null)
            {
                return new Libro();
            }
            else
            {
                return librodesedb;
            }

        }

        public Task<List<Libro>> GetLibros()
        {
            return _appDbContext.Libros.ToListAsync();
        }
    }
}
