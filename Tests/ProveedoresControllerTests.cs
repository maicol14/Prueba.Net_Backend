using Moq;
using Xunit;
using ProveedoresAPI.Controlador;
using ProveedoresAPI.Modelo;
using ProveedoresAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ProveedoresAPI.Tests
{
    public class ProveedoresControllerTests
    {
        private readonly ProveedoresController _controller;
        private readonly Mock<IProveedorRepository> _mockRepo;

        public ProveedoresControllerTests()
        {
            _mockRepo = new Mock<IProveedorRepository>();
            _controller = new ProveedoresController(_mockRepo.Object);
        }

        [Fact]
        public void GetProveedor_ReturnsOkResult_WhenProveedorExists()
        {
            // Arrange
            var proveedorId = "22333333";
            _mockRepo.Setup(repo => repo.GetById(proveedorId));

            // Act
            var result = _controller.Get(proveedorId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        
    }
}
