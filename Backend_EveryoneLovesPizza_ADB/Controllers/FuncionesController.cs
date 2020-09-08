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
    public class FuncionesController : ControllerBase
    {
        private readonly ProyectoABDContext _context;

        public FuncionesController(ProyectoABDContext context)
        {
            _context = context;
        }

        // GET: api/Funciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funciones>>> GetFunciones()
        {
            return await _context.Funciones.ToListAsync();
        }

        // GET: api/Funciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funciones>> GetFunciones(int id)
        {
            var funciones = await _context.Funciones.FindAsync(id);

            if (funciones == null)
            {
                return NotFound();
            }

            return funciones;
        }

        // PUT: api/Funciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunciones(int id, Funciones funciones)
        {
            if (id != funciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(funciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionesExists(id))
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

        // POST: api/Funciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Funciones>> PostFunciones(Funciones funciones)
        {
            _context.Funciones.Add(funciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunciones", new { id = funciones.Id }, funciones);
        }

        // DELETE: api/Funciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funciones>> DeleteFunciones(int id)
        {
            var funciones = await _context.Funciones.FindAsync(id);
            if (funciones == null)
            {
                return NotFound();
            }

            _context.Funciones.Remove(funciones);
            await _context.SaveChangesAsync();

            return funciones;
        }

        private bool FuncionesExists(int id)
        {
            return _context.Funciones.Any(e => e.Id == id);
        }
    }
}
