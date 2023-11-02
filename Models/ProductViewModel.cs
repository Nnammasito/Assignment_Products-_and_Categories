#pragma warning disable CS8618
namespace Assignment_Products__and_Categories.Models
{
    public class ProductView{
        public Product? Product {get;set;} = new Product();
        public List<Product> Products {get;set;} = new List<Product>();
    }
}