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
    public class OnderzoekController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public OnderzoekController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Onderzoek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoeken()
        {
            return Ok(await _context.Onderzoeken.ToListAsync());
        }

        // GET: api/Onderzoek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Onderzoek>> GetOnderzoek(int id)
        {
            var Onderzoek = await _context.Onderzoeken.FindAsync(id);

            if (Onderzoek == null)
            {
                return NotFound();
            }

            return Ok(Onderzoek);
        }

        // PUT: api/Onderzoek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnderzoek(int id, Onderzoek Onderzoek)
        {
            if (id != Onderzoek.Id)
            {
                return BadRequest();
            }

            _context.Entry(Onderzoek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnderzoekExists(id))
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

        // POST: api/Onderzoek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Onderzoek>> PostOnderzoek(Onderzoek Onderzoek)
        {
            _context.Onderzoeken.Add(Onderzoek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnderzoek", new { id = Onderzoek.Id }, Onderzoek);
        }

        // DELETE: api/Onderzoek/5
        // Add special authorisation?
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnderzoek(int id)
        {
            var Onderzoek = await _context.Onderzoeken.FindAsync(id);
            if (Onderzoek == null)
            {
                return NotFound();
            }

            _context.Onderzoeken.Remove(Onderzoek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnderzoekExists(int id)
        {
            return _context.Onderzoeken.Any(e => e.Id == id);
        }
    }
}
