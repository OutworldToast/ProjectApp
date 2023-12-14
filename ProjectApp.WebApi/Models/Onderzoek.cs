namespace ProjectApp.WebApi.Models;

public class Onderzoek {

    public Guid Id{get;set;}
    public string? Titel {get;set;}
    public string? Beschrijving{get;set;}
    public DateTime Onderzoeksdatum{get;set;}
    public DateOnly Tijdslimiet{get;set;}
    public string? TypeBeperking{get;set;}
    public string? SoortOnderzoek{get;set;}
    public int HoeveelheidDeelnemers{get;set;}
    public int Beloning{get;set;}
    public string? Status{get;set;}
    
}