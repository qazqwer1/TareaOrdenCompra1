namespace Tarea.DTO
{
    public class OrdenProductoDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }

    public class OrdenCompraCreateDto
    {
        public string Cliente { get; set; } = string.Empty;
        public List<OrdenProductoDto> Productos { get; set; } = new();
    }

}
