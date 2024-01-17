using Microsoft.AspNetCore.Mvc;
using ProjectApp.WebApi.Data;
using ProjectApp.WebApi.Models;

namespace ProjectApp.WebApi.Controllers;

[ApiController]
[Route("Api/{controller}")]
public class OnderzoekController : ControllerBase
{
    private OnderzoekContext _context;

    public OnderzoekController(OnderzoekContext context) {
        _context = context;
    }

    [HttpGet("/{id}")]
    public Onderzoek GetOnderzoek(int id)
    {
        return _context.Onderzoeken.Single(o => id == o.Id);
    }
}
