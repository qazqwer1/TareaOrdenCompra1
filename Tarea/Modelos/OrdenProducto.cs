namespace Tarea.Modelos
{
    public class OrdenProducto
    {
        public int Id { get; set; }

        public int OrdenId { get; set; }
        public OrdenCompra Orden { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
