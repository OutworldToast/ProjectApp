namespace ProjectApp.WebApi.Models;

public class Deelname {
    public string? Id {get; set;}
    
    //FKs
    public Panellid? Panellid {get; set;}
    public string? PanellidId {get; set;}
    public Onderzoek? Onderzoek {get; set;}
    public string? OnderzoekId {get; set;}

    //body
    public string? Contact {get; set;}
    public string? Status {get; set;}
}