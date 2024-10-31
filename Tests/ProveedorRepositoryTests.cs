using Moq;
using MongoDB.Driver;
using ProveedoresAPI.Data;
using ProveedoresAPI.Modelo;
using ProveedoresAPI.Repositorios;
using Xunit;

namespace ProveedoresAPI.Tests
{
    public class ProveedorRepositoryTests
    {
        private readonly Mock<ProveedorContext> _mockContext;
        private readonly ProveedorRepository _repository;
        private readonly Mock<IMongoCollection<Proveedor>> _mockCollection;

        public ProveedorRepositoryTests()
        {
            // Configura el mock de la colección
            _mockCollection = new Mock<IMongoCollection<Proveedor>>();

            // Configura el mock de ProveedorContext
            _mockContext = new Mock<ProveedorContext>();
            _mockContext.Setup(c => c.Proveedores).Returns(_mockCollection.Object);

            // Crea la instancia del repositorio con el contexto simulado
            _repository = new ProveedorRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsAllProveedores()
        {
            // Arrange
            var proveedores = new List<Proveedor>
            {
                new Proveedor { NIT = "22333333", RazonSocial = "Proveedor 1" },
              
            };

            var mockCursor = new Mock<IAsyncCursor<Proveedor>>();
            mockCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);
            mockCursor.SetupGet(_ => _.Current).Returns(proveedores);

          

            // Act
            var result = await _repository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        
    }
}
