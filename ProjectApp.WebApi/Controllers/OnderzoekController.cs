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

        // GET: api/Onderzoek/Beperking?id=2
        [HttpGet("Beperking")]
        public async Task<ActionResult<Onderzoek>> GetOnderzoekByBeperking([FromQuery] int id)
        {
            var beperking = await _context.Beperkingen.FindAsync(id);
            if (beperking == null) {
                return NotFound("Geen beperking met deze ID gevonden");
            }
            var onderzoeken = await _context.Onderzoeken.Where(o => o.BeperkingId == id).ToListAsync();

            return Ok(onderzoeken);
        }

        // PUT: api/Onderzoek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnderzoek(int id, [FromBody] Onderzoek Onderzoek)
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
        public async Task<ActionResult<Onderzoek>> PostOnderzoek([FromBody] Onderzoek onderzoek)
        {
            if (onderzoek.Tijdslimiet > onderzoek.Onderzoeksdatum) {
                return BadRequest("Tijdslimiet niet toegestaan");
            }

            var beperking = await _context.Beperkingen.FindAsync(onderzoek.BeperkingId);
            if (beperking == null) {
                return NotFound("Geen beperking met deze ID gevonden");
            }
            onderzoek.TypeBeperking = beperking;

            var bedrijf = await _context.Bedrijven.FindAsync(onderzoek.BedrijfId);
            if (beperking == null) {
                return NotFound("Bedrijf bestaat niet");
            }
            onderzoek.Bedrijf = bedrijf;

            onderzoek.Status = "Open";

            _context.Onderzoeken.Add(onderzoek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnderzoek", new { id = onderzoek.Id }, onderzoek);
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
