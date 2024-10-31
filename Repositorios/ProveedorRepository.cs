using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProveedoresAPI.Data;
using ProveedoresAPI.Modelo;

namespace ProveedoresAPI.Repositorios
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ProveedorContext _context;

        public ProveedorRepository(ProveedorContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetAll()
        {
            return await _context.Proveedores.Find(p => true).ToListAsync();
        }

        public async Task<Proveedor> GetById(string nit)
        {
            return await _context.Proveedores.Find(p => p.NIT == nit).FirstOrDefaultAsync();
        }

        public async Task Create(Proveedor proveedor)
        {
            await _context.Proveedores.InsertOneAsync(proveedor);
        }

        public async Task Update(string nit, Proveedor proveedor)
        {
            await _context.Proveedores.ReplaceOneAsync(p => p.NIT == nit, proveedor);
        }

        public async Task Delete(string nit)
        {
            await _context.Proveedores.DeleteOneAsync(p => p.NIT == nit);
        }
    }
}
