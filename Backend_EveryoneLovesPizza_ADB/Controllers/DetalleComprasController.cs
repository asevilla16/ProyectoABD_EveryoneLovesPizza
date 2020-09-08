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
    public class DetalleComprasController : ControllerBase
    {
        private readonly ProyectoABDContext _context;

        public DetalleComprasController(ProyectoABDContext context)
        {
            _context = context;
        }

        // GET: api/DetalleCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCompra>>> GetDetalleCompra()
        {
            return await _context.DetalleCompra.ToListAsync();
        }

        // GET: api/DetalleCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCompra>> GetDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompra.FindAsync(id);

            if (detalleCompra == null)
            {
                return NotFound();
            }

            return detalleCompra;
        }

        // PUT: api/DetalleCompras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCompra(int id, DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCompraExists(id))
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

        // POST: api/DetalleCompras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalleCompra>> PostDetalleCompra(DetalleCompra detalleCompra)
        {
            _context.DetalleCompra.Add(detalleCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCompra", new { id = detalleCompra.Id }, detalleCompra);
        }

        // DELETE: api/DetalleCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleCompra>> DeleteDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompra.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            _context.DetalleCompra.Remove(detalleCompra);
            await _context.SaveChangesAsync();

            return detalleCompra;
        }

        private bool DetalleCompraExists(int id)
        {
            return _context.DetalleCompra.Any(e => e.Id == id);
        }
    }
}
