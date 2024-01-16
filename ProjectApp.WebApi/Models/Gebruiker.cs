using Microsoft.AspNetCore.Identity;

namespace ProjectApp.WebApi.Models;

public class Gebruiker : IdentityUser<int> {

    //Body
    public string? Voornaam {get; set;}
    public string? Achternaam {get; set;}
    public string? Adres {get; set;}
    public string? Postcode {get; set;}
    public int Telefoonnummer {get; set;}
    
}