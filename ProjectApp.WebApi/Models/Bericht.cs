namespace ProjectApp.WebApi.Models;

public class Bericht {
    //PK
    public int Id {get; set;}

    //FKs
    public Chat? Chat {get; set;}
    public int ChatId {get; set;}

    //Body
    public string? Inhoud {get; set;}
    public DateTime Tijdstip {get; set;}

}