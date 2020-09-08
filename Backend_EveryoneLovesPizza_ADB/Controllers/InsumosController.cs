using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_EveryoneLovesPizza_ADB.Models;

namespace Backend_EveryoneLovesPizza_ADB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosController : ControllerBase
    {
        private readonly ProyectoABDContext _context;

        public InsumosController(ProyectoABDContext context)
        {
            _context = context;
        }

        // GET: api/Insumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insumos>>> GetInsumos()
        {
            return await _context.Insumos.ToListAsync();
        }

        // GET: api/Insumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insumos>> GetInsumos(int id)
        {
            var insumos = await _context.Insumos.FindAsync(id);

            if (insumos == null)
            {
                return NotFound();
            }

            return insumos;
        }

        // PUT: api/Insumos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsumos(int id, Insumos insumos)
        {
            if (id != insumos.Id)
            {
                return BadRequest();
            }

            _context.Entry(insumos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsumosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Insumos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Insumos>> PostInsumos(Insumos insumos)
        {
            _context.Insumos.Add(insumos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsumos", new { id = insumos.Id }, insumos);
        }

        // DELETE: api/Insumos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Insumos>> DeleteInsumos(int id)
        {
            var insumos = await _context.Insumos.FindAsync(id);
            if (insumos == null)
            {
                return NotFound();
            }

            _context.Insumos.Remove(insumos);
            await _context.SaveChangesAsync();

            return insumos;
        }

        private bool InsumosExists(int id)
        {
            return _context.Insumos.Any(e => e.Id == id);
        }
    }
}
