namespace ProjectApp.WebApi.Models;

public class Bericht {

    //FKs
    public Guid Gebruiker1Id {get; set;}
    public Guid Gebruiker2Id {get; set;}

    //Body
    public string? Inhoud {get; set;}
    public DateTime Tijdstip {get; set;}

}