namespace ProjectApp.WebApi.Models;

public class Bericht {
    //PK
    public string? Id {get; set;}

    //FKs
    public string? Gebruiker1Id {get; set;}
    public string? Gebruiker2Id {get; set;}

    //Body
    public string? Inhoud {get; set;}
    public DateTime Tijdstip {get; set;}

}