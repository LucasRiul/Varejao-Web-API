using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varejao.Data;
using Varejao.Model;

namespace DesafioBackEnd.Controllers
{
    [ApiController]
    [Route("v1/hortifruti")]
    public class HortifrutiController : ControllerBase
    {
        private VarejaoContext _context = new VarejaoContext();

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var hortifruti = await _context.Hortifruti.AsNoTracking().ToListAsync();
            return Ok(hortifruti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var hortifruti = await _context.Hortifruti.AsNoTracking().FirstOrDefaultAsync(x => x.IdHortifruti == id);
            return hortifruti == null ? NotFound() : Ok(hortifruti);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] Hortifruti model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hortifruti = new Hortifruti
            {
                Nome = model.Nome,
                EstoqueMinimo = model.EstoqueMinimo,
                EstoqueAtual = model.EstoqueAtual,
                PrecoCusto = model.PrecoCusto,
                PrecoVenda = model.PrecoVenda,
                Cofins = model.Cofins,
                Iss = model.Iss,
                Icms = model.Icms,
            };

            try
            {
                await _context.Hortifruti.AddAsync(hortifruti);
                await _context.SaveChangesAsync();
                return Created($"v1/hortifruti/{hortifruti.IdHortifruti}", hortifruti);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] Hortifruti model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hortifruti = await _context.Hortifruti.FirstOrDefaultAsync(x => x.IdHortifruti == id);

            if (hortifruti == null)
                return NotFound();

            try
            {
                hortifruti.Nome = model.Nome;
                hortifruti.EstoqueMinimo = model.EstoqueMinimo;
                hortifruti.EstoqueAtual = model.EstoqueAtual;
                hortifruti.PrecoCusto = model.PrecoCusto;
                hortifruti.PrecoVenda = model.PrecoVenda;
                hortifruti.Cofins = model.Cofins;
                hortifruti.Iss = model.Iss;
                hortifruti.Icms = model.Icms;

                _context.Hortifruti.Update(hortifruti);
                await _context.SaveChangesAsync();
                return Ok(hortifruti);
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
            var hortifruti = await _context.Hortifruti.FirstOrDefaultAsync(x => x.IdHortifruti == id);

            try
            {
                _context.Hortifruti.Remove(hortifruti);
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
