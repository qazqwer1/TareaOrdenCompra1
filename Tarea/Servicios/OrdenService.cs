using Tarea.DTO;
using Tarea.Modelos;
using Tarea.Repositorios;

namespace Tarea.Servicios
{
    public class OrdenService
    {
        private readonly IOrdenRepositorio _ordenRepository;
        private readonly IProductoRepositorio _productoRepository;

        public OrdenService(IOrdenRepositorio ordenRepository, IProductoRepositorio productoRepository)
        {
            _ordenRepository = ordenRepository;
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<OrdenCompra>> ObtenerTodas(int page, int pageSize)
        {
            return await _ordenRepository.GetAllAsync(page, pageSize);
        }


        public async Task<OrdenCompra?> ObtenerPorId(int id)
        {
            return await _ordenRepository.GetByIdAsync(id);
        }

        public async Task<OrdenCompra> Crear(OrdenCompra orden)
        {
            // Cargar precios de productos y calcular total
            decimal total = 0;
            foreach (var op in orden.Productos)
            {
                var producto = await _productoRepository.GetByIdAsync(op.ProductoId);
                if (producto != null)
                {
                    op.Producto = producto;
                    total += producto.Precio;
                }
            }

            // Aplicar descuento
            orden.Total = AplicarDescuento(total, orden.Productos.Count);

            return await _ordenRepository.AddAsync(orden);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _ordenRepository.DeleteAsync(id);
        }

        public async Task<OrdenCompra?> Actualizar(int id, OrdenCompraUpdateDto dto)
        {
            var ordenExistente = await _ordenRepository.GetByIdAsync(id);
            if (ordenExistente == null)
                return null;

            ordenExistente.Productos.Clear();

            decimal total = 0;
            int cantidadTotalProductos = 0;

            foreach (var item in dto.Productos)
            {
                var producto = await _productoRepository.GetByIdAsync(item.ProductoId);
                if (producto != null)
                {
                    for (int i = 0; i < item.Cantidad; i++)
                    {
                        ordenExistente.Productos.Add(new OrdenProducto
                        {
                            ProductoId = producto.Id,
                            Producto = producto
                        });

                        total += producto.Precio;
                        cantidadTotalProductos++;
                    }
                }
            }

            ordenExistente.Cliente = dto.Cliente;
            ordenExistente.FechaCreacion = DateTime.UtcNow;
            ordenExistente.Total = AplicarDescuento(total, cantidadTotalProductos);

            return await _ordenRepository.UpdateAsync(id, ordenExistente);
        }

        protected internal decimal AplicarDescuento(decimal total, int cantidad)
        {
           
            if (total > 500)
                return total * 0.90m;

            else if (cantidad > 5)
                return total * 0.95m;

            return total;
        }


        public async Task<OrdenCompra> CrearDesdeDto(OrdenCompraCreateDto dto)
        {
            var orden = new OrdenCompra
            {
                Cliente = dto.Cliente,
                FechaCreacion = DateTime.UtcNow,
                Productos = new List<OrdenProducto>()
            };

            decimal total = 0;
            int cantidadTotalProductos = 0;

            foreach (var item in dto.Productos)
            {
                var producto = await _productoRepository.GetByIdAsync(item.ProductoId);
                if (producto != null)
                {
                    for (int i = 0; i < item.Cantidad; i++)
                    {
                        orden.Productos.Add(new OrdenProducto
                        {
                            ProductoId = producto.Id,
                            Producto = producto
                        });
                        total += producto.Precio;
                        cantidadTotalProductos++;
                    }
                }
            }

            orden.Total = AplicarDescuento(total, cantidadTotalProductos);

            return await _ordenRepository.AddAsync(orden);
        }

        public OrdenCompraDto MapearADto(OrdenCompra orden)
        {
            return new OrdenCompraDto
            {
                Id = orden.Id,
                Cliente = orden.Cliente,
                FechaCreacion = orden.FechaCreacion,
                Total = orden.Total,
                Productos = orden.Productos.Select(p => new ProductoDto
                {
                    Id = p.Producto.Id,
                    Nombre = p.Producto.Nombre,
                    Precio = p.Producto.Precio
                }).ToList()
            };
        }

        public async Task<PaginacionDto<OrdenCompraDto>> ObtenerPaginado(int page, int pageSize)
{
    var ordenes = await _ordenRepository.GetAllAsync(page, pageSize);
    var total = await _ordenRepository.GetTotalCountAsync();

    var dtos = ordenes.Select(o => MapearADto(o));

    return new PaginacionDto<OrdenCompraDto>
    {
        TotalItems = total,
        PaginaActual = page,
        TamanoPagina = pageSize,
        TotalPaginas = (int)Math.Ceiling(total / (double)pageSize),
        Items = dtos
    };
}





    }
}
