using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varejao.Data;
using Varejao.Model;

namespace DesafioBackEnd.Controllers
{
    [ApiController]
    [Route("v1/lote")]
    public class LotesController : ControllerBase
    {
        private VarejaoContext _context = new VarejaoContext();

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lotes = await _context.Lote.AsNoTracking().ToListAsync();
            return Ok(lotes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var lote = await _context.Lote.AsNoTracking().FirstOrDefaultAsync(x => x.IdLote == id);
            return lote == null ? NotFound() : Ok(lote);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] Lote model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lote = new Lote
            {
                QuantidadeHortifruti = model.QuantidadeHortifruti,
                DataValidade = model.DataValidade,                
                IdHortifruti = model.IdHortifruti,
                Fornecedor = model.Fornecedor,
            };

            try
            {
                await _context.Lote.AddAsync(lote);
                await _context.SaveChangesAsync();
                return Created($"v1/lote/{lote.IdLote}", lote);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] Lote model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lote = await _context.Lote.FirstOrDefaultAsync(x => x.IdLote == id);

            if (lote == null)
                return NotFound();

            try
            {
                lote.QuantidadeHortifruti = model.QuantidadeHortifruti;
                lote.DataValidade = model.DataValidade;
                lote.IdHortifruti = model.IdHortifruti;

                _context.Lote.Update(lote);
                await _context.SaveChangesAsync();
                return Ok(lote);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id)
        {
            var lote = await _context.Lote.FirstOrDefaultAsync(x => x.IdLote == id);

            try
            {
                _context.Lote.Remove(lote);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);

            }
        }
    }
}
