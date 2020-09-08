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
    public class OrdenVentasController : ControllerBase
    {
        private readonly ProyectoABDContext _context;

        public OrdenVentasController(ProyectoABDContext context)
        {
            _context = context;
        }

        // GET: api/OrdenVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenVenta>>> GetOrdenVenta()
        {
            return await _context.OrdenVenta.ToListAsync();
        }

        // GET: api/OrdenVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenVenta>> GetOrdenVenta(int id)
        {
            var ordenVenta = await _context.OrdenVenta.FindAsync(id);

            if (ordenVenta == null)
            {
                return NotFound();
            }

            return ordenVenta;
        }

        // PUT: api/OrdenVentas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenVenta(int id, OrdenVenta ordenVenta)
        {
            if (id != ordenVenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenVentaExists(id))
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

        // POST: api/OrdenVentas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdenVenta>> PostOrdenVenta(OrdenVenta ordenVenta)
        {
            _context.OrdenVenta.Add(ordenVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenVenta", new { id = ordenVenta.Id }, ordenVenta);
        }

        // DELETE: api/OrdenVentas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenVenta>> DeleteOrdenVenta(int id)
        {
            var ordenVenta = await _context.OrdenVenta.FindAsync(id);
            if (ordenVenta == null)
            {
                return NotFound();
            }

            _context.OrdenVenta.Remove(ordenVenta);
            await _context.SaveChangesAsync();

            return ordenVenta;
        }

        private bool OrdenVentaExists(int id)
        {
            return _context.OrdenVenta.Any(e => e.Id == id);
        }
    }
}
