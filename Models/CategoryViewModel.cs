#pragma warning disable CS8618
namespace Assignment_Products__and_Categories.Models
{
    public class CategoryViewModel{
        public Category? Category {get;set;} = new Category();
        public List<Category> Categories {get;set;} = new List<Category>();
    }
}