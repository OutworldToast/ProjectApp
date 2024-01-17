using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Models;

namespace ProjectApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BeperkingController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public BeperkingController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Beperking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beperking>>> GetBeperkingen()
        {
            return await _context.Beperkingen.ToListAsync();
        }

        // GET: api/Beperking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beperking>> GetBeperking(int id)
        {
            var beperking = await _context.Beperkingen.FindAsync(id);

            if (beperking == null)
            {
                return NotFound();
            }

            return beperking;
        }

        // PUT: api/Beperking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeperking(int id, Beperking beperking)
        {
            if (id != beperking.Id)
            {
                return BadRequest();
            }

            _context.Entry(beperking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeperkingExists(id))
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

        // POST: api/Beperking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beperking>> PostBeperking(Beperking beperking)
        {
            _context.Beperkingen.Add(beperking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeperking", new { id = beperking.Id }, beperking);
        }

        // DELETE: api/Beperking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeperking(int id)
        {
            var beperking = await _context.Beperkingen.FindAsync(id);
            if (beperking == null)
            {
                return NotFound();
            }

            _context.Beperkingen.Remove(beperking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeperkingExists(int id)
        {
            return _context.Beperkingen.Any(e => e.Id == id);
        }
    }
}
