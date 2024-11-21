using System.ComponentModel.DataAnnotations;

namespace Algebra.WebShop.Models;

public class ProductCategory
{
    [Key] 
    public int Id { get; set; }
    public int ProductId { get; set; }
    [Required]
    public virtual  required Product Product { get; set; }
    public int CategoryId { get; set; }
    [Required]
    public virtual required Category Category { get; set; }

}
