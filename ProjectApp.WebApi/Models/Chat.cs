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
    

}