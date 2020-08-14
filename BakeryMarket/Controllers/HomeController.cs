using Microsoft.AspNetCore.Mvc;

namespace BakeryMarket.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}