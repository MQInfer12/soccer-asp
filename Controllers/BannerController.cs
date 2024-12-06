using asp_test.Data;
using asp_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_test.Controllers
{
  public class BannerController : Controller
  {
    private readonly DBContext db;

    public BannerController(DBContext context)
    {
      db = context;
    }

    // GET: /Banner
    public IActionResult Index()
    {
      var clubs = db.Clubs.ToList();
      ViewBag.Clubs = clubs;
      var oldBanner = db.Banners.FirstOrDefault();
      return View(oldBanner);
    }


    // POST: /Banner
    [HttpPost]
    public IActionResult SaveBanner(Banner banner)
    {
      var oldBanner = db.Banners.FirstOrDefault();

      if (!ModelState.IsValid)
      {
        var clubs = db.Clubs.ToList();
        ViewBag.Clubs = clubs;
        return View("Index", oldBanner);
      }

      if (oldBanner == null)
      {
        oldBanner = new Banner
        {
          Club1Id = banner.Club1Id,
          Club2Id = banner.Club2Id,
          Description = banner.Description
        };
        db.Banners.Add(oldBanner);
      }
      else
      {
        oldBanner.Club1Id = banner.Club1Id;
        oldBanner.Club2Id = banner.Club2Id;
        oldBanner.Description = banner.Description;
        db.Banners.Update(oldBanner);
      }

      db.SaveChanges();
      return RedirectToAction("Index");
    }

    
    // POST: Banner/DeleteConfirmed
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
      Console.WriteLine(id);
      var banner = db.Banners.FirstOrDefault(p => p.Id == id);
      if (banner != null)
      {
        db.Banners.Remove(banner);
        db.SaveChanges();
      }
      return RedirectToAction(nameof(Index));
    }
  }
}