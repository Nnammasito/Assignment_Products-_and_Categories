namespace Assignment_Products__and_Categories.Models
{
    public class MyViewModelCategory
    {
        public List<Product> Products {get;set;} = new List<Product>();

        public Category Category {get;set;} = new Category();

        public int? PorductID {get;set;}
    }
}

