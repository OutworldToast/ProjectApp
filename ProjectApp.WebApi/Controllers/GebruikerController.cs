using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.WebApi.Models;

public class GebruikerMetWachtwoord {

    public string? Wachtwoord {get; init;}
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

    public GebruikerController(UserManager<Gebruiker> userManager, SignInManager<Gebruiker> signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("registreer")]
    public async Task<ActionResult> Registreer([FromBody] GebruikerMetWachtwoord gebruikerDTO) {
        if (gebruikerDTO.Wachtwoord == null || gebruikerDTO.Emailadres == null) {
            return BadRequest();
        }

        Gebruiker gebruiker = new()
        {
            Email = gebruikerDTO.Emailadres,
            UserName = gebruikerDTO.Emailadres
        };

        var resultaat = await _userManager.CreateAsync(gebruiker, gebruikerDTO.Wachtwoord);
        return !resultaat.Succeeded ? BadRequest(resultaat) : Created();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] GebruikerLogin gebruiker){ //identityoptions.requireemailunique ofzo
        if (gebruiker.Emailadres == null || gebruiker.Wachtwoord == null) {
            return BadRequest();
        }
        var _user = await _userManager.FindByEmailAsync(gebruiker.Emailadres);

        //change second bool for 'remember me'
        if (_user != null) {
            var signin = await _signInManager.PasswordSignInAsync(_user, gebruiker.Wachtwoord, gebruiker.RememberMe, true);
            return signin.Succeeded ? Ok() : Unauthorized();
        }

        return Unauthorized();

    }
}