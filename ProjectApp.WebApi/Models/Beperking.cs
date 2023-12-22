namespace ProjectApp.WebApi.Models;

public class Beperking {
    //PK
    public int Id {get; set;}

    //FKs
    public List<Panellid> Panelleden {get; set;} = [];
    public List<Onderzoek> Onderzoeken {get; set;} = [];

    //Body
    public string? Categorie {get; set;}
}