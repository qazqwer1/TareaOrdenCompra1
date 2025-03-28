namespace Tarea.DTO
{
    public class OrdenCompraUpdateDto
    {
        public string Cliente { get; set; } = string.Empty;
        public List<OrdenProductoDto> Productos { get; set; } = new();
    }

}
