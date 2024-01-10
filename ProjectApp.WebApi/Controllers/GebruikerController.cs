using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.WebApi.Models;

public class GebruikerMetWachtwoord: IdentityUser<int>{
    public string? Wachtwoord {get; init;}
}

public class GebruikerLogin{
    [Required]
    public string? Emailadres { get; init; }
    [Required]
    public string? Wachtwoord { get; init; }
}

[Route("api/[controller]")]
[ApiController]
public class GebruikerController: ControllerBase {

    private readonly UserManager<IdentityUser<int>> _userManager;
    private readonly SignInManager<IdentityUser<int>> _signInManager;

    public GebruikerController(UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("registreer")]
    public async Task<ActionResult> Registreer([FromBody] GebruikerMetWachtwoord gebruiker) {
        if (gebruiker.Wachtwoord == null) {
            return BadRequest(gebruiker);
        }

        var resultaat = await _userManager.CreateAsync(gebruiker, gebruiker.Wachtwoord);
        return !resultaat.Succeeded ? BadRequest(resultaat) : Created();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] GebruikerLogin gebruiker){ //identityoptions.requireemailunique ofzo
        if (gebruiker.Emailadres == null) {
            return BadRequest(gebruiker);
        }
        var _user = await _userManager.FindByEmailAsync(gebruiker.Emailadres);

        if (_user != null) {
            await _signInManager.SignInAsync(_user, true);
            return Ok();
        }

        return Unauthorized();


    }
}