using Microsoft.AspNetCore.Mvc;
using SalesMvcProject.Services;

namespace SalesMvcProject.Controllers;

public class SellersController(SellerService service) : Controller
{
    private readonly SellerService _sellerService = service;
    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }
}