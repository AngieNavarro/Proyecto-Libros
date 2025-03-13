using ProyectoLibros.Components.Modelos;

namespace ProyectoLibros.Components.Repositorio
{
    public interface IRepositorio
    {
        public Task<List<Libro>> GetLibros();

        public Task<Libro> GetLibroId(int libroid);

        public Task<Libro> CrearLibro(Libro crearLibro);
        public Task<Libro> ActualizarLibro(int libroid, Libro actLibro);

        public Task EliminarLibro (int libroid);



    }
}
