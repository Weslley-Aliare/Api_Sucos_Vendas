using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Actions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IActionVendedores _vendedoresRepositore;

        public VendedorController(IActionVendedores vendedoresRepositore)
        {
            _vendedoresRepositore = vendedoresRepositore;
        }

        [HttpGet]
        public async Task<IEnumerable<TabelaDeVendedore>> GetTabelaDeVendedore()
        {
            return await _vendedoresRepositore.Get();
        }

        [HttpGet("{Matricula}")]
        public async Task<ActionResult<TabelaDeVendedore>> GetTabelaDeVendedore(string Matricula)
        {
            return await _vendedoresRepositore.Get(Matricula);
        }

        [HttpPost]
        public async Task<ActionResult<TabelaDeVendedore>> PostTabelaDeVendedore([FromBody] TabelaDeVendedore tabelaDeVendedore)
        {
            var newVendedor = await _vendedoresRepositore.Create(tabelaDeVendedore);
            return CreatedAtAction(nameof(GetTabelaDeVendedore), new { Matricula = newVendedor.Matricula }, newVendedor);
        }

        [HttpDelete("{Matricula}")]
        public async Task<ActionResult> Delete(string Matricula)
        {
            var vendedorToDelete = await _vendedoresRepositore.Get(Matricula);
                if (vendedorToDelete == null)
                return NotFound();

            await _vendedoresRepositore.Delete(vendedorToDelete.Matricula);
                return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutTabelaDeVendedore(string idMatricula, [FromBody] TabelaDeVendedore tabelaDeVendedore)
        {
            if(idMatricula == tabelaDeVendedore.Matricula)
                return BadRequest();
            await _vendedoresRepositore.Update(tabelaDeVendedore);
            return NoContent();
        }
    }
}
