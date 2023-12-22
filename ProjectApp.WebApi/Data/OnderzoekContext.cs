using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Models;

namespace ProjectApp.WebApi.Data;

public class OnderzoekContext : DbContext {

    public OnderzoekContext (DbContextOptions o) : base(o) {
        
    }

    //gebruikers
    public DbSet<Gebruiker> Gebruikers {get;set;}
    public DbSet<Panellid> Panelleden {get;set;}
    public DbSet<Bedrijf> Bedrijven {get;set;}

    //chat
    public DbSet<Chat> Chats {get;set;}
    public DbSet<Bericht> Berichten {get;set;}

    //onderzoeken
    public DbSet<Onderzoek> Onderzoeken {get;set;}
    public DbSet<Deelname> Deelnames {get;set;}

    //neveninformatie
    public DbSet<Beperking> Beperkingen {get;set;}
    public DbSet<Voogd> Voogden {get;set;}

}