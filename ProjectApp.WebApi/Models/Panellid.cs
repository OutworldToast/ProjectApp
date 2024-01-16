namespace ProjectApp.WebApi.Models;

//->> misschien extra constraints nodig om ID consistent te houden tussen gebruiker overervingen?
public class Panellid : Gebruiker {

    //FKs
    public Voogd? Voogd {get; set;}

    //Body
    public List<Beperking> Beperkingen {get; set;} = [];
    public List<string> Hulpmiddelen {get; set;} = [];
    public string? Benaderingsvoorkeur {get; set;}
    public bool Onafhankelijk {get; set;}
}