using System.ComponentModel.DataAnnotations;
namespace ProyectoLibros.Components.Modelos
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La Descripccion es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Autor es obligatorio")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Las paginas son obligatorias")]
        public string Paginas { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public int Precio { get; set; }
        public DateTime  FechaCreacion { get; set; }
    }
}
