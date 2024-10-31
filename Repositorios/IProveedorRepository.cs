using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresAPI.Modelo;

namespace ProveedoresAPI.Repositorios
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> GetAll();
        Task<Proveedor> GetById(string nit);
        Task Create(Proveedor proveedor);
        Task Update(string nit, Proveedor proveedor);
        Task Delete(string nit);
    }
}
