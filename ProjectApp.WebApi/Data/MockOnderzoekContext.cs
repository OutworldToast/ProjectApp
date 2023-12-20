using Microsoft.EntityFrameworkCore;
using ProjectApp.WebApi.Models;

namespace ProjectApp.WebApi.Data;

public class MockOnderzoekContext : DbContext {

    public MockOnderzoekContext (DbContextOptions o) : base(o) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
    }

    public DbSet<Onderzoek> Onderzoeken {get;set;}

}