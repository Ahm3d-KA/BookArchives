using Microsoft.AspNetCore.Mvc;

namespace BookArchives.Controllers;

public class ExploreController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}