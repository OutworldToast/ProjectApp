namespace ProjectApp.WebApi.Models;

public class Deelname {
    public Guid Id {get; set;}
    
    //FKs
    public Panellid? Panellid {get; set;}
    public Guid? PanellidId {get; set;}
    public Onderzoek? Onderzoek {get; set;}
    public Guid? OnderzoekId {get; set;}

    //body
    public string? Contact {get; set;}
    public string? Status {get; set;}
}