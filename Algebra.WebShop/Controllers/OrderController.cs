using Algebra.WebShop.Data;
using Algebra.WebShop.Extensions;
using Algebra.WebShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Algebra.WebShop.Controllers;

[Authorize]
public class OrderController(ApplicationDbContext context) : Controller
{

    private string? GetCurrentUserId()
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return userId;
    }
    public IActionResult Index(bool? success)
    {
       
        

        ViewData["Success"] = success;
        var cart = HttpContext.Session.GetCart();
        ViewData["Cart"]= HttpContext.Session.GetCart();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("FirstName,LastName,PhoneNumber,CustomerEmailAdress,CustomerAdress")] Order order)
    {
        ModelState.Remove("Items");
        if (ModelState.IsValid)
        {
            var cart = HttpContext.Session.GetCart();
            order.UserId = GetCurrentUserId()!;
            order.Total = cart.GrandTotal;
            order.DateTimeCreated = DateTime.UtcNow;
            context.Orders.Add(order);
            context.SaveChanges();
            if (cart.Items.Count > 0)
            {
              foreach(var cartItem in cart.Items)
                {
                    var item = new OrderItem()
                    {
                        OrderId = order.Id,
                        Price = cartItem.Product.Price,
                        Quantity = cartItem.Quantity,
                        Total = cartItem.Total,
                        ProductId = cartItem.Product.Id
                    };
                    context.OrderItems.Add(item);
                }
                context.SaveChanges();
            }
            HttpContext.Session.ClearCart();

            return RedirectToAction(nameof(Index), new {success = true});
        }
        else
        {
            foreach(var item in ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    Console.WriteLine(error);
                } 
            }
//            ViewData["Errors"] = error
;        }
        return View();
    }
}
