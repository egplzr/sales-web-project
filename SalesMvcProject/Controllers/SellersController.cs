using Microsoft.AspNetCore.Mvc;
using SalesMvcProject.Models;
using SalesMvcProject.Models.ViewModels;
using SalesMvcProject.Services;

namespace SalesMvcProject.Controllers;

public class SellersController(SellerService sellerService, DepartmentService departmentService) : Controller
{
    private readonly SellerService _sellerService = sellerService;
    private readonly DepartmentService _departmentService = departmentService;
    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }

    public IActionResult Create()
    {
        var departments = _departmentService.FindAll();
        var viewModel = new SellerFormViewModel {Departments = departments};
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();

        var obj = _sellerService.FindById(id.Value);
        if (obj == null) return NotFound();

        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _sellerService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound();

        var obj = _sellerService.FindById(id.Value);
        if (obj == null) return NotFound();

        return View(obj);
    }
}