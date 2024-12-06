using asp_test.Data;
using asp_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_test.Controllers
{
  public class PlayersController : Controller
  {
    private readonly DBContext db;

    public PlayersController(DBContext context)
    {
      db = context;
    }

    // GET: Players
    public IActionResult Index()
    {
      var players = db.Players.ToList();
      return View(players);
    }

    // GET: Players/Details/5
    public IActionResult Details(int id)
    {
      var player = db.Players.FirstOrDefault(p => p.Id == id);
      if (player == null) return NotFound();
      return View(player);
    }

    // GET: Players/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Players/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Player player)
    {
      if (ModelState.IsValid)
      {
        db.Players.Add(player);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(player);
    }

    // GET: Players/Edit/5
    public IActionResult Edit(int id)
    {
      var player = db.Players.FirstOrDefault(p => p.Id == id);
      if (player == null) return NotFound();
      return View(player);
    }

    // POST: Players/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Player player)
    {
      if (id != player.Id) return BadRequest();
      if (ModelState.IsValid)
      {
        db.Players.Update(player);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(player);
    }

    // GET: Players/Delete/5
    public IActionResult Delete(int id)
    {
      var player = db.Players.FirstOrDefault(p => p.Id == id);
      if (player == null) return NotFound();
      return View(player);
    }

    // POST: Players/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
      var player = db.Players.FirstOrDefault(p => p.Id == id);
      if (player != null)
      {
        db.Players.Remove(player);
        db.SaveChanges();
      }
      return RedirectToAction(nameof(Index));
    }
  }
}