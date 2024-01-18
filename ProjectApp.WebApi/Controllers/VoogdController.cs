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
    public class VoogdController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public VoogdController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Voogd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voogd>>> GetVoogden()
        {
            return Ok(await _context.Voogden.ToListAsync());
        }

        // GET: api/Voogd/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voogd>> GetVoogd(int id)
        {
            var voogd = await _context.Voogden.FindAsync(id);

            if (voogd == null)
            {
                return NotFound();
            }

            return Ok(voogd);
        }

        // PUT: api/Voogd/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoogd(int id, Voogd voogd)
        {
            if (id != voogd.Id)
            {
                return BadRequest();
            }

            _context.Entry(voogd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoogdExists(id))
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

        // POST: api/Voogd
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voogd>> PostVoogd(Voogd voogd)
        {
            _context.Voogden.Add(voogd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoogd", new { id = voogd.Id }, voogd);
        }

        // DELETE: api/Voogd/5
        // Add special authorisation?
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoogd(int id)
        {
            var voogd = await _context.Voogden.FindAsync(id);
            if (voogd == null)
            {
                return NotFound();
            }

            _context.Voogden.Remove(voogd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoogdExists(int id)
        {
            return _context.Voogden.Any(e => e.Id == id);
        }
    }
}
