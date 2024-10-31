using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProveedoresAPI.Controlador;
using ProveedoresAPI.Modelo;
using Moq;
using System.Collections.Generic;
using ProveedoresAPI.Repositorios;

public class ProveedoresControllerTests
{
    [Fact]
    public void GetAll_ShouldReturnOkResult()
    {
        // Arrange
        var mockRepo = new Mock<IProveedorRepository>();
        mockRepo.Setup(repo => repo.GetAll()).Returns(GetProveedores());
        var controller = new ProveedoresController(mockRepo.Object);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var proveedores = Assert.IsAssignableFrom<List<Proveedor>>(okResult.Value);
        Assert.Equal(3, proveedores.Count);
    }

    public async Task<List<Proveedor>> GetProveedores()
    {
        return new List<Proveedor>
        {
            new Proveedor { NIT = "12345", RazonSocial = "Proveedor 1" },
            new Proveedor { NIT = "67890", RazonSocial = "Proveedor 2" },
            new Proveedor { NIT = "54321", RazonSocial = "Proveedor 3" }
        };
    }
}

