using Moq;
using Tarea.Modelos;
using Tarea.Repositorios;
using Tarea.Servicios;
using Tarea.DTO;
using Xunit;

namespace Tarea.Tests.Servicios
{
    public class OrdenServiceTests
    {
        public class OrdenServiceFake : OrdenService
        {
            public OrdenServiceFake() : base(null!, null!) { }

            public decimal ProbarDescuento(decimal total, int cantidad)
            {
                return AplicarDescuento(total, cantidad);
            }
        }

        public class AplicarDescuentoTests
        {
            [Theory]
            [InlineData(600, 2, 540)]   // Aplica 10% por total > 500
            [InlineData(400, 6, 380)]   // Aplica 5% por cantidad > 5
            [InlineData(400, 3, 400)]   // No aplica descuento
            public void AplicarDescuento_DeberiaRetornarTotalEsperado(decimal total, int cantidad, decimal esperado)
            {
                // Arrange
                var service = new OrdenServiceFake();

                // Act
                var resultado = service.ProbarDescuento(total, cantidad);

                // Assert
                Assert.Equal(esperado, resultado);
            }
        }
    }
}
