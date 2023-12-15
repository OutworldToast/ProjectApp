using Microsoft.AspNetCore.Identity;

namespace ProjectApp.WebApi.Models;

public class Gebruiker : IdentityUser<Guid> {

    public string? Adres {get; set;}
    public string? Postcode {get; set;}
    public int Telefoonnummer {get; set;}
    public string? Emailadres {get; set;}
    
}