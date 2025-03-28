using Tarea.Modelos;
using Tarea.Repositorios;

namespace Tarea.Servicios
{
    public class ProductoService
    {
        private readonly IProductoRepositorio _productoRepository;

        public ProductoService(IProductoRepositorio productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Task<IEnumerable<Producto>> ObtenerTodos() => _productoRepository.GetAllAsync();
        public Task<Producto?> ObtenerPorId(int id) => _productoRepository.GetByIdAsync(id);
        public Task<Producto> Crear(Producto producto) => _productoRepository.AddAsync(producto);
    }
}
