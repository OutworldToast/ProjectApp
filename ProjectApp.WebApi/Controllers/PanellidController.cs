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
    public class PanellidController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public PanellidController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Panellid
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panellid>>> GetPanelleden()
        {
            return Ok(await _context.Panelleden.ToListAsync());
        }

        // GET: api/Panellid/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panellid>> GetPanellid(int id)
        {
            var panellid = await _context.Panelleden.FindAsync(id);

            if (panellid == null)
            {
                return NotFound();
            }

            return Ok(panellid);
        }

        // PUT: api/Panellid/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanellid(int id, Panellid panellid)
        {
            if (id != panellid.Id)
            {
                return BadRequest();
            }

            _context.Entry(panellid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanellidExists(id))
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

        // POST: api/Panellid
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Panellid>> PostPanellid(Panellid panellid)
        {
            _context.Panelleden.Add(panellid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanellid", new { id = panellid.Id }, panellid);
        }

        // DELETE: api/Panellid/5
        // Add special authorisation?
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanellid(int id)
        {
            var panellid = await _context.Panelleden.FindAsync(id);
            if (panellid == null)
            {
                return NotFound();
            }

            _context.Panelleden.Remove(panellid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanellidExists(int id)
        {
            return _context.Panelleden.Any(e => e.Id == id);
        }
    }
}
