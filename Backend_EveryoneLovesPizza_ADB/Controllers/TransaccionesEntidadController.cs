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
    public class TransaccionesEntidadController : ControllerBase
    {
        private readonly ProyectoABDContext _context;

        public TransaccionesEntidadController(ProyectoABDContext context)
        {
            _context = context;
        }

        // GET: api/TransaccionesEntidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransaccionesEntidad>>> GetTransaccionesEntidad()
        {
            return await _context.TransaccionesEntidad.ToListAsync();
        }

        // GET: api/TransaccionesEntidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransaccionesEntidad>> GetTransaccionesEntidad(int id)
        {
            var transaccionesEntidad = await _context.TransaccionesEntidad.FindAsync(id);

            if (transaccionesEntidad == null)
            {
                return NotFound();
            }

            return transaccionesEntidad;
        }

        // PUT: api/TransaccionesEntidad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccionesEntidad(int id, TransaccionesEntidad transaccionesEntidad)
        {
            if (id != transaccionesEntidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaccionesEntidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionesEntidadExists(id))
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

        // POST: api/TransaccionesEntidad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransaccionesEntidad>> PostTransaccionesEntidad(TransaccionesEntidad transaccionesEntidad)
        {
            _context.TransaccionesEntidad.Add(transaccionesEntidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransaccionesEntidadExists(transaccionesEntidad.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransaccionesEntidad", new { id = transaccionesEntidad.Id }, transaccionesEntidad);
        }

        // DELETE: api/TransaccionesEntidad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransaccionesEntidad>> DeleteTransaccionesEntidad(int id)
        {
            var transaccionesEntidad = await _context.TransaccionesEntidad.FindAsync(id);
            if (transaccionesEntidad == null)
            {
                return NotFound();
            }

            _context.TransaccionesEntidad.Remove(transaccionesEntidad);
            await _context.SaveChangesAsync();

            return transaccionesEntidad;
        }

        private bool TransaccionesEntidadExists(int id)
        {
            return _context.TransaccionesEntidad.Any(e => e.Id == id);
        }
    }
}
