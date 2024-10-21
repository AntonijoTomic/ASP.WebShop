using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.WebShop.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    // TODO: Dodati user ID
    [Required]
    [Column(TypeName = "decimal(9, 2)")]
    public decimal Total { get; set; }

    [ForeignKey("OrderId")]
    public virtual ICollection<OrderItem> Items { get; set; }   
}
