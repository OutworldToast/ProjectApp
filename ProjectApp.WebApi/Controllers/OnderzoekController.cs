using Microsoft.AspNetCore.Mvc;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Models;

namespace ProjectApp.WebApi.Controllers;

[ApiController]
[Route("Api/{controller}")]
public class OnderzoekController : ControllerBase
{
    
    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    private OnderzoekContext _context;

    public OnderzoekController(OnderzoekContext context) {
        _context = context;
    }

    [HttpGet(Name = "GetOnderzoek")]
    [Route("/{id}")]
    public Onderzoek GetOnderzoek(int id)
    {
        return _context.Onderzoeken.Single(o => id == o.Id);
    }
}
