using Xunit;
using ProveedoresAPI.Repositorios;
using ProveedoresAPI.Modelo;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProveedorRepositoryTests
{
    [Fact]
    public async Task GetAll_ShouldReturnAllProveedores()
    {
        // Arrange
        var mockRepo = new Mock<IProveedorRepository>();

        // Usa ReturnsAsync para devolver una tarea con una lista de proveedores
        mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(GetProveedores());
        var repository = mockRepo.Object;

        // Act
        var result = await repository.GetAll();

        // Assert
        Assert.Equal(3, result.Count); // Asegúrate de que estás esperando 3 proveedores
    }

    private List<Proveedor> GetProveedores()
    {
        // Devuelve una lista de proveedores
        return new List<Proveedor>
        {
            new Proveedor { NIT = "12345", RazonSocial = "Proveedor 1" },
            new Proveedor { NIT = "67890", RazonSocial = "Proveedor 2" },
            new Proveedor { NIT = "54321", RazonSocial = "Proveedor 3" }
        };
    }
}
