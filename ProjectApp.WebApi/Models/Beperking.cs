namespace ProjectApp.WebApi.Models;

public class Beperking {
    public Guid Id {get; set;}
    public string? Categorie {get; set;}
    public List<Panellid> Panelleden {get; set;} = [];
    public List<Onderzoek> Onderzoeken {get; set;} = [];
}