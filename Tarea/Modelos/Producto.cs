using System.ComponentModel.DataAnnotations;

namespace Tarea.Modelos
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }
    }
}
