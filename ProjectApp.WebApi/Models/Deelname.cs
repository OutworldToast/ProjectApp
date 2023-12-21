namespace ProjectApp.WebApi.Models;

public class Deelname {
    //PK
    public int Id {get; set;}
    
    //FKs
    public Panellid? Panellid {get; set;}
    public int PanellidId {get; set;}
    public Onderzoek? Onderzoek {get; set;}
    public int OnderzoekId {get; set;}

    //body
    public string? Contact {get; set;}
    public string? Status {get; set;}
}