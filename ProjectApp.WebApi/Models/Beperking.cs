using System.Text.Json.Serialization;

namespace ProjectApp.WebApi.Models;

public class Beperking {
    //PK
    public int Id {get; set;}

    //FKs
    public List<Panellid> Panelleden {get; set;} = [];
    [JsonIgnore]
    public List<Onderzoek> Onderzoeken {get; set;} = [];

    //Body
    public string? Categorie {get; set;}
}