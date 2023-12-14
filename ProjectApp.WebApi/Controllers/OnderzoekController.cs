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
    public IEnumerable<Onderzoek> Get(Guid id)
    {
        return _context.Onderzoeken.Where(o => id == o.Id).ToList();
    }
}
