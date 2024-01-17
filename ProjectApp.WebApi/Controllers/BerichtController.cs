using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Models;


namespace ProjectApp.WebApi.Controllers
{

    public class BerichtPost {
    
        [Required]
        public int ChatId {get; init;}
        [Required]
        public string? Inhoud {get; init;} 

    }

    [Route("api/[controller]")]
    [ApiController]
    public class BerichtController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public BerichtController(OnderzoekContext context)
        {
            _context = context;
        }

        // GET: api/Bericht
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bericht>>> Getberichten()
        {
            return await _context.Berichten.ToListAsync();
        }

        // GET: api/Bericht/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bericht>> Getbericht(int id)
        {
            var bericht = await _context.Berichten.FindAsync(id);

            if (bericht == null)
            {
                return NotFound();
            }

            return bericht;
        }

        // PUT: api/Bericht/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBericht(int id, Bericht bericht)
        {
            if (id != bericht.Id)
            {
                return BadRequest();
            }

            _context.Entry(bericht).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BerichtExists(id))
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

        // POST: api/Bericht
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bericht>> Postbericht(BerichtPost berichtPost)
        {
            Bericht bericht = new Bericht {
                Chat = await _context.Chats.FindAsync(berichtPost.ChatId),
                ChatId = berichtPost.ChatId,
                Inhoud = berichtPost.Inhoud,
                Tijdstip = DateTime.Now
            };

            if (bericht.Chat == null || bericht.Inhoud == null) {
                return BadRequest();
            }

            _context.Berichten.Add(bericht);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbericht", new { id = bericht.Id }, bericht);
        }

        // DELETE: api/Bericht/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBericht(int id)
        {
            var bericht = await _context.Berichten.FindAsync(id);
            if (bericht == null)
            {
                return NotFound();
            }

            _context.Berichten.Remove(bericht);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BerichtExists(int id)
        {
            return _context.Berichten.Any(e => e.Id == id);
        }
    }
}
