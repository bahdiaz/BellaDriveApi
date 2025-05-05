using Microsoft.AspNetCore.Mvc;
using LocadoraApi.Data;
using LocadoraApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BellaDriveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> Get() => await _context.Carros.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetById(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            return carro == null ? NotFound() : Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> Post(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = carro.Id }, carro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Carro carro)
        {
            if (id != carro.Id) return BadRequest();
            _context.Entry(carro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}