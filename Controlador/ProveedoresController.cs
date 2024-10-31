
using Microsoft.AspNetCore.Mvc;
using ProveedoresAPI.Modelo;
using ProveedoresAPI.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProveedoresAPI.Controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedoresController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> Get()
        {
            return await _proveedorRepository.GetAll();
        }

        [HttpGet("{nit}")]
        public async Task<ActionResult<Proveedor>> Get(string nit)
        {
            var proveedor = await _proveedorRepository.GetById(nit);
            if (proveedor == null) return NotFound();
            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Proveedor proveedor)
        {
            await _proveedorRepository.Create(proveedor);
            return CreatedAtAction(nameof(Get), new { nit = proveedor.NIT }, proveedor);
        }

        [HttpPut("{nit}")]
        public async Task<IActionResult> Update(string nit, [FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest("El proveedor es requerido.");
            }

            try
            {
                await _proveedorRepository.Update(nit, proveedor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{nit}")]
        public async Task<ActionResult> Delete(string nit)
        {
            await _proveedorRepository.Delete(nit);
            return NoContent();
        }
    }
}

