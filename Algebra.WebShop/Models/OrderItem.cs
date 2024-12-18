﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.WebShop.Models;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    public required int OrderId { get; set; }

    public required int ProductId { get; set; }
    [Required]
    [Column(TypeName = "decimal(9, 3)")]
    public decimal Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(9, 2)")]
    public decimal Price { get; set; }
    [Required]
    [Column(TypeName = "decimal(9, 2)")]
    public decimal Total { get; set; }

    [NotMapped]
    public string ProductName { get; set; }

}
