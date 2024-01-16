using Microsoft.Identity.Client;
using NuGet.Protocol.Plugins;

namespace ProjectApp.WebApi.Models;

public class Chat {
    //PK
    public int Id {get; set;}

    //FKs
    public Gebruiker? Gebruiker1 {get; set;}
    public Gebruiker? Gebruiker2 {get; set;}
    public List<Bericht> Berichten {get; set;} = [];

    //Body
    public string? Naam {get; set;}

    public ChatHeader ChatHeader() {
        return new ChatHeader(Id, Gebruiker1, Gebruiker2, Naam);
    }
    
}

//DTO om chat te returnen zonder de berichten
public class ChatHeader(int id, Gebruiker gebruiker1, Gebruiker gebruiker2, string naam)
{
    public int Id { get; init; } = id;
    public Gebruiker? Gebruiker1 { get; init; } = gebruiker1;
    public Gebruiker? Gebruiker2 { get; init; } = gebruiker2;
    public string? Naam { get; init; } = naam;
}