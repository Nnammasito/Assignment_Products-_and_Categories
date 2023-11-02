#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_Products__and_Categories.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The Name field is required")]
    [MinLength(2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Description field is required")]
    [DataType(DataType.Text)]
    public string Description { get; set; }

    [Required(ErrorMessage = "The price field is required")]
    public Decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association>? Association { get; set; } = new List<Association>();
}