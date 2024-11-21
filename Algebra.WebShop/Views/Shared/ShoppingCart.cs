using Algebra.WebShop.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.WebShop.Views.Shared;

//[ViewComponent(Name ="ShoppingCart")]
public class ShoppingCart : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var cart = HttpContext.Session.GetCart();


        return View("Default", cart);
    }
}
