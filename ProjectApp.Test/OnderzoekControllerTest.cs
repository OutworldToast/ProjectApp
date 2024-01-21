namespace ProjectApp.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Controllers;
using System.Diagnostics;
using ProjectApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

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

        
        _context.Beperkingen.AddRange(
            new Beperking {
                Id = 1,
                Categorie = "Slechtziend"
            }
        );

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
                },
            new Onderzoek {
                Id = 2, 
                Beloning = 5, 
                BeperkingId = 2, 
                Beschrijving = "Onderzoek iets anders", 
                HoeveelheidDeelnemers = 1,
                Onderzoeksdatum = DateTime.Now.Date,
                SoortOnderzoek = "Iets",
                Status = "Gaande", 
                Tijdslimiet = DateTime.Now.AddDays(7).Date, 
                Titel = "IetsAndersOnderzoek", 
                TypeBeperking = null
                }
        );

        _context.SaveChanges();

    }

    [Fact]
    public async void GetOnderzoekenTest() {
        //arrange
        OnderzoekController controller = new(_context);
        //->> fixture

        //act
        var result = await controller.GetOnderzoeken();

        //assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Onderzoek>>>(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.IsType<List<Onderzoek>>(okObjectResult.Value);
    }

    [Fact]
    public async void GetOnderzoekExistsTest() {
    //arrange
    OnderzoekController controller = new(_context);

    //act
    var result = await controller.GetOnderzoek(1);
    //->> fixture

    //assert
    var actionResult = Assert.IsType<ActionResult<Onderzoek>>(result);
    var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
    var onderzoek = Assert.IsType<Onderzoek>(okObjectResult.Value);
    Assert.Equal(5, onderzoek.Beloning);
    }

    [Fact]
    public async void GetOnderzoekNotExistsTest() {
        //arrange
        OnderzoekController controller = new(_context);

        //act
        var result = await controller.GetOnderzoek(20);
        //->> fixture

        //assert
        var actionResult = Assert.IsType<ActionResult<Onderzoek>>(result);
        Assert.IsType<NotFoundObjectResult>(actionResult.Result);
    }

    [Fact]
    public async void GetOnderzoekenByBeperkingExistsTest() {
        //arrange
        OnderzoekController controller = new(_context);
        //->> fixture

        //act
        var result = await controller.GetOnderzoekenByBeperking(1);

        //assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Onderzoek>>>(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
        var onderzoek = Assert.IsType<Onderzoek>(okObjectResult.Value);
        Assert.Equal(1, onderzoek.Id);
    }

    [Fact]
    public async void GetOnderzoekenByBeperkingNotExistsTest() {
        //arrange
        OnderzoekController controller = new(_context);
        //->> fixture

        //act
        var result = await controller.GetOnderzoekenByBeperking(2);

        //assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Onderzoek>>>(result);
        Assert.IsType<NotFoundObjectResult>(actionResult);
    }

    [HttpPost]
        public async void PostOnderzoekInvalidTimelimitTest ()
        {
            //arrange
            OnderzoekController controller = new(_context);
            Onderzoek o = new() {
                Id = 1, 
                Beloning = 5, 
                BeperkingId = 1, 
                Beschrijving = "Onderzoek iets", 
                HoeveelheidDeelnemers = 1,
                Onderzoeksdatum = DateTime.Now.AddDays(7).Date,
                SoortOnderzoek = "Iets",
                Status = "Gaande", 
                Tijdslimiet = DateTime.Now.Date, 
                Titel = "IetsOnderzoek", 
                TypeBeperking = null
            };

            //act
            var result = await controller.PostOnderzoek(o);

            // if (onderzoek.Tijdslimiet < onderzoek.Onderzoeksdatum) {
            //     return BadRequest("Tijdslimiet niet toegestaan");
            // }

            // var beperking = await _context.Beperkingen.FindAsync(onderzoek.BeperkingId);
            // if (beperking == null) {
            //     return NotFound("Geen beperking met deze ID gevonden");
            // }
            // onderzoek.TypeBeperking = beperking;

            // var bedrijf = await _context.Bedrijven.FindAsync(onderzoek.BedrijfId);
            // if (beperking == null) {
            //     return NotFound("Bedrijf bestaat niet");
            // }
            // onderzoek.Bedrijf = bedrijf;

            // onderzoek.Status = "Open";

            // _context.Onderzoeken.Add(onderzoek);
            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetOnderzoek", new { id = onderzoek.Id }, onderzoek);
        }

    //Gooit na elke test het database weg
    public void Dispose() {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }

}