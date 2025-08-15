using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musicaApi.Context;
using musicaApi.Models;

namespace musicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class escuelasController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public escuelasController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/escuelas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<escuela>>> GetEscuela()
        {
            return await _context.Escuela.ToListAsync();
        }

        // GET: api/escuelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<escuela>> Getescuela(int id)
        {
            var escuela = await _context.Escuela.FindAsync(id);

            if (escuela == null)
            {
                return NotFound();
            }

            return escuela;
        }

        // PUT: api/escuelas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putescuela(int id, escuela escuela)
        {
            if (id != escuela.id)
            {
                return BadRequest();
            }

            _context.Entry(escuela).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!escuelaExists(id))
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

        // POST: api/escuelas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<escuela>> Postescuela(escuela escuela)
        {
            _context.Escuela.Add(escuela);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getescuela", new { id = escuela.id }, escuela);
        }

        // DELETE: api/escuelas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteescuela(int id)
        {
            var escuela = await _context.Escuela.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }

            _context.Escuela.Remove(escuela);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool escuelaExists(int id)
        {
            return _context.Escuela.Any(e => e.id == id);
        }
    }
}
