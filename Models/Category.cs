#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Assignment_Products__and_Categories.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The Name field is required")]
    [MinLength(2)]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association>? Associationn { get; set; } = new List<Association>();
}