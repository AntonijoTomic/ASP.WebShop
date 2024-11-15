using Algebra.WebShop.Extensions;
using Algebra.WebShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.WebShop.Controllers;

public class OrderController : Controller
{
    public IActionResult Index()
    {
        //var cart = HttpContext.Session.GetCart();
        ViewData["Cart"]= HttpContext.Session.GetCart();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOrder([Bind("FirstName,LastName,PhoneNumber,CustomerEmailAdress")] Order order)
    {

        return View();
    }
}
