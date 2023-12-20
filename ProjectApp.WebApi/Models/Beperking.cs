namespace ProjectApp.WebApi.Models;

public class Beperking {
    public string? Id {get; set;}

    //FKs
    public List<Panellid> Panelleden {get; set;} = [];
    public List<Onderzoek> Onderzoeken {get; set;} = [];

    //Body
    public string? Categorie {get; set;}
}