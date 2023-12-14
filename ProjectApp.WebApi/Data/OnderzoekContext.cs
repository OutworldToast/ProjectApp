using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Models;

namespace ProjectApp.WebApi.Data;

public class OnderzoekContext : DbContext {

    public OnderzoekContext (DbContextOptions o) : base(o) {
        
    }

    public DbSet<Onderzoek> Onderzoeken {get;set;}

}