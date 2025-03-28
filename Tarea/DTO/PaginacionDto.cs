namespace Tarea.DTO
{
    public class PaginacionDto<T>
    {
        public int TotalItems { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
        public int TamanoPagina { get; set; }
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }

}
