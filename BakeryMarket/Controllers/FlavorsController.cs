using Microsoft.AspNetCore.Mvc;
using BakeryMarket.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BakeryMarket.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly BakeryMarketContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, BakeryMarketContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    [Authorize]
    public ActionResult Create()
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor, int treatId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      if (treatId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flavor.FlavorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
        .Include(flavor => flavor.Treats)
        .ThenInclude(join => join.Treat)
        .Include(flavor => flavor.User)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null ? userId == thisFlavor.User.Id : false;
      return View(thisFlavor);
    }

    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavor => flavor.FlavorId == id);
      if (thisFlavor == null)
      {
        return RedirectToAction("Details", new { id = id });
      }
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor, int treatId)
    {
      if (treatId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flavor.FlavorId });
      }
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavor => flavor.FlavorId == id);
      if (thisFlavor == null)
      {
        return RedirectToAction("Details", new { id = id });
      }
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteTreat(int joinId)
    {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}