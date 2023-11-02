#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Products__and_Categories.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }


    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}