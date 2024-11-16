using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.WebShop.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DateTimeCreated { get; set; }

    [Required]
    [Column(TypeName = "decimal(9, 2)")]
    public decimal Total { get; set; }

    [Required(ErrorMessage ="Customer's first name is required!")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Customer's last name is required!")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Customer's email is required!")]
    [StringLength(50)]
    public string CustomerEmailAdress { get; set; }


    [Required(ErrorMessage = "Customer's phone num is required!")]
    public string PhoneNumber { get; set; }


    [Required(ErrorMessage = "Customer's Adress is required!")]
    [StringLength(50)]
    public string CustomerAdress { get; set; }

    [ForeignKey("OrderId")]
    public virtual ICollection<OrderItem> Items { get; set; }


    public virtual ApplicationUser User{ get; set; }
    [Required]
    public  string UserId { get; set; }
}
