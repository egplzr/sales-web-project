using Microsoft.AspNetCore.Mvc;

namespace SalesMvcProject.Controllers;

public class SellersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}