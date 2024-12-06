using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_test.Models;
using asp_test.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace asp_test.Controllers;

public class HomeController : Controller
{
    private readonly DBContext db;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, DBContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet]
    public IActionResult Index([FromQuery] DateOnly? date)
    {
        var banner = db.Banners
            .Include(b => b.Club1)
            .Include(b => b.Club2)
            .FirstOrDefault();

        var tournaments = db.Tournaments
            .Include(t => t.Games)
                .ThenInclude(g => g.Club1)
            .Include(t => t.Games)
                .ThenInclude(g => g.Club2)
            .ToList()
            .Select(t => new
            {
                t.Name,
                t.Description,
                GamesCount = t.Games.Count,
                GamesByDate = t.Games
                    .Where(g => !date.HasValue || g.Date == date.Value)
                    .GroupBy(g => g.Date)
                    .Select(group => new
                    {
                        Date = group.Key.ToString("MMMM dd, yyyy", new CultureInfo("en-US")),
                        Games = group.ToList()
                    })
                    .ToList()
            })
            .Where(t => t.GamesByDate.Any(gb => gb.Games.Any()))
            .ToList();

        ViewBag.Tournaments = tournaments;

        // Pasar fecha formateada y valor crudo para el input
        ViewBag.FilteredDate = date.HasValue
            ? date.Value.ToString("MMMM dd, yyyy", new CultureInfo("en-US"))
            : "All Matches";
        ViewBag.FilteredDateValue = date.HasValue
            ? date.Value.ToString("yyyy-MM-dd")
            : "";

        return View(banner);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
