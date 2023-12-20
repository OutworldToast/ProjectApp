namespace ProjectApp.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Controllers;
using System.Diagnostics;
using ProjectApp.WebApi.Models;



public class OnderzoekControllerTest : IDisposable
{

    private OnderzoekContext _context;

    //onderzoek heeft attributen:
    //id
    //typebeperking
    //beperkingid
    //titel
    //beschrijving
    //onderzoeksdatum
    //tijdslimiet
    //soortonderzoek
    //hoeveelheid deelnemers
    //beloning
    //status


    //Maakt voor elke test een inMemoryDatabase aan
    public OnderzoekControllerTest () {
        var _contextOptions = new DbContextOptionsBuilder<OnderzoekContext>()
        .UseInMemoryDatabase("OnderzoekControllerTest")
        .Options;

        var context = new OnderzoekContext(_contextOptions);
        this._context = context;

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Onderzoeken.AddRange(
            new Onderzoek {}
        );


    }

    [Fact]
    public void Test1() {

    }

    //Gooit na elke test het database weg
    public void Dispose() {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }

}