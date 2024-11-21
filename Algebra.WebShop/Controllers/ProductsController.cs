using Algebra.WebShop.Data;
using Algebra.WebShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Algebra.WebShop.Controllers;

public class ProductsController(ApplicationDbContext context) : Controller //primary constructor
{
 
    public IActionResult Index(int ? categoryId)
    {
        ViewData["Categories"] = new SelectList(context.Categories, "Id", "Name");
        var products = context.Products.ToList();

        if(categoryId != null)
        {
            products = (

                from product in context.Products
                join productCategory in context.ProductCategories on product.Id equals productCategory.ProductId
                where productCategory.CategoryId == categoryId
                select  product).ToList();
        }

        return View(products);
    }
}
