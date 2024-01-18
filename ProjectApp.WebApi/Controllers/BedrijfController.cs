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
    public class BedrijfController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public BedrijfController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Bedrijf
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bedrijf>>> GetBedrijven()
        {
            return Ok(await _context.Bedrijven.ToListAsync());
        }

        // GET: api/Bedrijf/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bedrijf>> GetBedrijf(int id)
        {
            var Bedrijf = await _context.Bedrijven.FindAsync(id);

            if (Bedrijf == null)
            {
                return NotFound();
            }

            return Ok(Bedrijf);
        }

        //GET api/Bedrijf/{id}/onderzoeken
        [HttpGet("{id}/deelnames")]
        public async Task<ActionResult<IEnumerable<Onderzoek>>> OnderzoekenVanGebruiker(int id) {

            try {
                
                var user = await _context.Bedrijven.SingleAsync(g => g.Id == id);
                return Ok(await _context.Onderzoeken.Where(o => o.BedrijfId == user.Id).ToListAsync());
                
            } catch (Exception) {
                return NotFound();
            }
        }

        // PUT: api/Bedrijf/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBedrijf(int id, [FromBody] Bedrijf Bedrijf)
        {
            if (id != Bedrijf.Id)
            {
                return BadRequest();
            }

            _context.Entry(Bedrijf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedrijfExists(id))
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

        // POST: api/Bedrijf
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bedrijf>> PostBedrijf([FromBody] Bedrijf Bedrijf)
        {
            _context.Bedrijven.Add(Bedrijf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBedrijf", new { id = Bedrijf.Id }, Bedrijf);
        }

        // DELETE: api/Bedrijf/5
        // Add special authorisation?
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBedrijf(int id)
        {
            var Bedrijf = await _context.Bedrijven.FindAsync(id);
            if (Bedrijf == null)
            {
                return NotFound();
            }

            _context.Bedrijven.Remove(Bedrijf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BedrijfExists(int id)
        {
            return _context.Bedrijven.Any(e => e.Id == id);
        }
    }
}
