using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasFiscaiController : ControllerBase
    {
        private readonly IActionNotasFiscais _notasFiscaiRepositorie;

        public NotasFiscaiController(IActionNotasFiscais notasFiscaiRepositorie)
        {
            _notasFiscaiRepositorie = notasFiscaiRepositorie;
        }
        
        [HttpGet]
        public async Task<IEnumerable<NotasFiscai>> GetNotasFiscai()
        {
            return await _notasFiscaiRepositorie.Get();
        }

        [HttpGet("{Numero}")]
        public async Task<ActionResult<NotasFiscai>> GetNotasFiscai(int Numero)
        {
            return await _notasFiscaiRepositorie.Get(Numero);
        }

        [HttpPost]
        public async Task<ActionResult<NotasFiscai>> PostNotasFiscai([FromBody] NotasFiscai notasFiscai)
        {
            var newNotaFiscal = await _notasFiscaiRepositorie.Create(notasFiscai);
            return CreatedAtAction(nameof(GetNotasFiscai), new { Numero = newNotaFiscal.Numero }, newNotaFiscal);
        }

        [HttpDelete("{Numero}")]
        public async Task<ActionResult> Delete(int Numero)
        {
            
            /*try
            {
                var notaFiscalToDelete = await _notasFiscaiRepositorie.Get(Numero);
                await _notasFiscaiRepositorie.Delete(notaFiscalToDelete.Numero);
            }
            catch(Exception ex)
            {
               
                //MessageBox.Show(ex.Message, "Nota fiscal não encontrada");
            }

            throw new NotImplementedException();*/





            var notaFiscalToDelete = await _notasFiscaiRepositorie.Get(Numero);
              if (notaFiscalToDelete == null)
                  return NotFound();

              await _notasFiscaiRepositorie.Delete(notaFiscalToDelete.Numero);
                  return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutNotasFiscai(int id, [FromBody] NotasFiscai notasFiscai)
        {
            if (id == notasFiscai.Numero)
                return BadRequest();

                await _notasFiscaiRepositorie.Update(notasFiscai);
            return NoContent();
        }
    }
}
