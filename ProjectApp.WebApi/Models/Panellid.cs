namespace ProjectApp.WebApi.Models;

//->> misschien extra constraints nodig om ID consistent te houden tussen gebruiker overervingen?
public class Panellid : Gebruiker {

    //FKs
    public Voogd? Voogd {get; set;}
    public List<Beperking> Beperkingen {get; set;} = [];
    

    //Body
    public string? Voornaam {get; set;}
    public string? Achternaam {get; set;}
    public string? Benaderingsvoorkeur {get; set;}
    public bool Onafhankelijk {get; set;}
}