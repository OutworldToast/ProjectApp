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

    public class DeelnamePost {
        public int OnderzoekId {get; init;}
        public int PanellidId {get; init;}
    }
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeelnameController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public DeelnameController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Deelname
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deelname>>> GetDeelnames()
        {
            return Ok(await _context.Deelnames.ToListAsync());
        }

        // GET: api/Deelname/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deelname>> GetDeelname(int id)
        {
            var Deelname = await _context.Deelnames.FindAsync(id);

            if (Deelname == null)
            {
                return NotFound();
            }

            return Ok(Deelname);
        }

        // PUT: api/Deelname/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeelname(int id, [FromBody] Deelname Deelname)
        {
            if (id != Deelname.Id)
            {
                return BadRequest();
            }

            _context.Entry(Deelname).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeelnameExists(id))
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

        // POST: api/Deelname
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deelname>> PostDeelname([FromBody] DeelnamePost deelnamePost)
        {
            var user = await _context.Panelleden.FindAsync(deelnamePost.PanellidId);
            var onderzoek = await _context.Onderzoeken.FindAsync(deelnamePost.OnderzoekId);

            if (user == null) {
                return NotFound("Geen panellid met deze ID gevonden");
            } else
            if (onderzoek == null) {
                return NotFound("Geen onderzoek met deze ID gevonden");
            }

            if (_context.Deelnames.Where(d => d.OnderzoekId == deelnamePost.OnderzoekId && d.PanellidId == deelnamePost.PanellidId).Any()) {
                return BadRequest("Deelname bestaat al");
            }

            Deelname deelname = new() {
                Onderzoek = onderzoek,
                OnderzoekId = deelnamePost.OnderzoekId,
                Panellid = user,
                PanellidId = deelnamePost.PanellidId,
                Status = "Actief",
            };

            _context.Deelnames.Add(deelname);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeelname", new { id = deelname.Id }, deelname);
        }

        // DELETE: api/Deelname/5
        // Add special authorisation?
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeelname(int id)
        {
            var Deelname = await _context.Deelnames.FindAsync(id);
            if (Deelname == null)
            {
                return NotFound();
            }

            _context.Deelnames.Remove(Deelname);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeelnameExists(int id)
        {
            return _context.Deelnames.Any(e => e.Id == id);
        }
    }
}
