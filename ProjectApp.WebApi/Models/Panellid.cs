namespace ProjectApp.WebApi.Models;

//->> misschien extra constraints nodig om ID consistent te houden tussen gebruiker overervingen?
public class Panellid : Gebruiker {
    public string? Voornaam {get; set;}
    public string? Achternaam {get; set;}
    public List<Beperking> Beperkingen {get; set;} = [];
    public List<String> Hulpmiddelen {get; set;} = [];
    public string? Benaderingsvoorkeur {get; set;}
    public bool Onafhankelijk {get; set;}
    
    public Voogd? Voogd {get; set;}
}