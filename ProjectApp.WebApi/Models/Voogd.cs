namespace ProjectApp.WebApi.Models;

public class Voogd {
    public Guid Id {get; set;}

    //FKs
    public Panellid? Panellid {get; set;}
    public Guid PanellidId {get; set;}

    //Body
    public string? Naam {get; set;}
    public int Telefoonnummer {get; set;}
    public string? Emailadres {get; set;}
}