#pragma warning disable CS8618


namespace Assignment_Products__and_Categories.Models;

public class MyViewModel
{
    public List<Category> Categories { get; set; } = new List<Category>();

    public Product Product { get; set; } = new Product();

    public int? CategoryID { get; set; }
}
