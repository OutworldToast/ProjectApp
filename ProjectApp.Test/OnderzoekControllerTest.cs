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
        
        var contextOptions = new DbContextOptionsBuilder<OnderzoekContext>()
        .UseInMemoryDatabase("OnderzoekControllerTest")
        .Options;

        var context = new OnderzoekContext(contextOptions);
        this._context = context;

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Onderzoeken.AddRange(
            new Onderzoek {
                Id = 1, 
                Beloning = 5, 
                BeperkingId = 1, 
                Beschrijving = "Onderzoek iets", 
                HoeveelheidDeelnemers = 1,
                Onderzoeksdatum = DateTime.Now.Date,
                SoortOnderzoek = "Iets",
                Status = "Gaande", 
                Tijdslimiet = DateTime.Now.AddDays(7).Date, 
                Titel = "IetsOnderzoek", 
                TypeBeperking = null
                }
        );

        _context.SaveChanges();

    }

    [Fact]
    public void GetOnderzoekExistsTest() {
        //arrange
        OnderzoekController controller = new(_context);

        //act
        var result = controller.GetOnderzoek(1).Beloning;

        //assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void GetOnderzoekNotExistsTest() {
        //arrange
        OnderzoekController controller = new(_context);

        //act
        // var result = controller.GetOnderzoek(20).Beloning;

        //assert
        Assert.Throws<InvalidOperationException>(() => controller.GetOnderzoek(20).Beloning);
    }

    //Gooit na elke test het database weg
    public void Dispose() {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }

}