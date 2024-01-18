using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Controllers;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Models;


//add regex for email??
public class GebruikerMetWachtwoord {

    public string? Wachtwoord {get; init;} //requires alphanumeric, number and uppercase
    public string? Emailadres {get; init;}
}

public class GebruikerLogin{
    [Required]
    public string? Emailadres { get; init; }
    [Required]
    public string? Wachtwoord { get; init; }
    public bool RememberMe { get; init;}
}

[Route("api/[controller]")]
[ApiController]
public class GebruikerController: ControllerBase {

    private readonly UserManager<Gebruiker> _userManager;
    private readonly SignInManager<Gebruiker> _signInManager;
    private readonly OnderzoekContext _context; 

    public GebruikerController(UserManager<Gebruiker> userManager, SignInManager<Gebruiker> signInManager, OnderzoekContext context) {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    [HttpPost("registreer")] //needs email confirmation
    public async Task<ActionResult> Registreer([FromBody] GebruikerMetWachtwoord gebruikerDTO) {
        if (gebruikerDTO.Wachtwoord == null || gebruikerDTO.Emailadres == null) {
            return BadRequest();
        }

        Gebruiker gebruiker = new()
        {
            Email = gebruikerDTO.Emailadres,
            UserName = gebruikerDTO.Emailadres
        };

        // ->> sendemail async 

        var resultaat = await _userManager.CreateAsync(gebruiker, gebruikerDTO.Wachtwoord);
        return !resultaat.Succeeded ? BadRequest(resultaat) : Created();
    }

    [HttpPost("login")] //should use JWT?
    public async Task<ActionResult> Login([FromBody] GebruikerLogin gebruiker){ //identityoptions.requireemailunique ofzo
        if (gebruiker.Emailadres == null || gebruiker.Wachtwoord == null) {
            return BadRequest();
        }
        var _user = await _userManager.FindByEmailAsync(gebruiker.Emailadres);

        if (_user != null) {
            var signin = await _signInManager.PasswordSignInAsync(_user, gebruiker.Wachtwoord, gebruiker.RememberMe, true);
            return signin.Succeeded ? Ok() : Unauthorized();
        }

        return Unauthorized();

    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout(){ //identityoptions.requireemailunique ofzo
        
        await _signInManager.SignOutAsync();

        return Ok();

    }

    // GET: api/Gebruiker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gebruiker>> GetGebruiker(int id)
        {
            var gebruiker = await _context.Gebruikers.FindAsync(id);

            if (gebruiker == null)
            {
                return NotFound();
            }

            return gebruiker;
        }

    //GET api/Gebruiker/{id}/deelnames
    [HttpGet("{id}/deelnames")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> OnderzoekenVanGebruiker(int id) {

        try {
            
            var user = await _context.Gebruikers.SingleAsync(g => g.Id == id);
            if (user.GetType() == typeof(Panellid)) {
                var controller = new PanellidController (_context);
                return await controller.OnderzoekenVanPanellid(id);
            } else 
            if (user.GetType() == typeof(Bedrijf)){
                
            }
            
            return Ok(await _context.Deelnames.Where(d => d.PanellidId == id).Select(d => d.Onderzoek).ToListAsync());
        } catch (Exception) {
            return NotFound();
        }
    }

    //moet voor panellid zijn
    //GET api/Gebruiker/{id}/onderzoeken
    [HttpGet("{id}/onderzoeken")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> OnderzoekenVoorGebruiker(int id) {

        try {
            var user = await _context.Panelleden.SingleAsync(g => g.Id == id);
            return Ok(await _context.Onderzoeken.Where(o => user.Beperkingen.Contains(o.TypeBeperking)).ToListAsync());
        } catch (Exception) {
            return NotFound();
        }

    }

    //GET api/Gebruiker/{id}/chats
    [HttpGet("{id}/chats")]
    //returnt chat zonder alle berichten
    public async Task<ActionResult<IEnumerable<ChatHeader>>> Chats(int id) {

         try {
            var user = await _context.Panelleden.SingleAsync(g => g.Id == id);
            return Ok(await _context.Chats.Where(c => c.Gebruiker1.Id == id || c.Gebruiker2.Id == id).Select(c => c.ChatHeader()).ToListAsync());
        } catch (Exception) {
            return NotFound();
        }

    }
}