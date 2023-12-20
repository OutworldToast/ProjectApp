namespace ProjectApp.WebApi.Models;

public class Voogd {
    public string? Id {get; set;}

    //FKs
    public Panellid? Panellid {get; set;}
    public string? PanellidId {get; set;}

    //Body
    public string? Naam {get; set;}
    public int Telefoonnummer {get; set;}
    public string? Emailadres {get; set;}
}