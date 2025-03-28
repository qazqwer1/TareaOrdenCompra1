namespace Tarea.DTO
{
    public class OrdenCompraDto
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public decimal Total { get; set; }
        public List<ProductoDto> Productos { get; set; } = new();
    }

}
