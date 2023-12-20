namespace ProjectApp.WebApi.Models;

public class Onderzoek {

    //PK
    public int Id {get;set;}
    
    //FKs
    public Beperking? TypeBeperking {get;set;}
    public int BeperkingId {get; set;}

    //Body
    public string? Titel {get;set;}
    public string? Beschrijving {get;set;}
    public DateTime Onderzoeksdatum {get;set;}
    public DateTime Tijdslimiet {get;set;}
    public string? SoortOnderzoek {get;set;}
    public int HoeveelheidDeelnemers {get;set;}
    public int Beloning {get;set;}
    public string? Status {get;set;}
    
}