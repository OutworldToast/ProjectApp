namespace ProjectApp.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Controllers;
using System.Diagnostics;
using ProjectApp.WebApi.Models;


//onderzoek heeft attributen:
//id
//titel
//beschrijving
//onderzoeksdatum
//tijdslimiet
//typebeperking
//soortonderzoek
// 

public class OnderzoekControllerTest : IDisposable
{

    private OnderzoekContext _context;

    public OnderzoekControllerTest () {
        var _contextOptions = new DbContextOptionsBuilder<OnderzoekContext>()
        .UseInMemoryDatabase("OnderzoekControllerTest")
        .Options;

        var context = new OnderzoekContext(_contextOptions);
        this._context = context;

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Onderzoeken.AddRange(
            new Onderzoek()
        );


    }

    [Fact]
    public void Test1()
    {
    }

    public void Dispose() {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }

}