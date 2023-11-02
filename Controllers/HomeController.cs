using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_Products__and_Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Products__and_Categories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        ProductView productView = new ProductView();
        productView.Products = _context.Products.ToList();
        return View("Index", productView);
    }

    [HttpPost("product/create")]
    public IActionResult CreateProduct([Bind(Prefix = "CreateProduct")]Product NewProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(NewProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("product/{id}")]
    public IActionResult ViewProduct(int id)
    {
        MyViewModel MyViewModelProduct = new MyViewModel();
        var temp = _context.Products
            .Include(p => p.Association)
            .FirstOrDefault(p => p.ProductId == id);
        var CategoryTemp = _context.Categories
            .Where(c => !c.Associationn.Any(p => p.ProductId == id))
            .ToList();
        if (temp != null && CategoryTemp != null)
        {
            MyViewModelProduct.Categories = CategoryTemp;
            MyViewModelProduct.Product = temp;
            return View("ViewProduct", MyViewModelProduct);
        }
        else 
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost("product/{id}/add")]
    public IActionResult AddCategory (int id, int? CategoryId)
    {
        var Temp = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (Temp == null)
        {
            return RedirectToAction("Index");
        }
        if (CategoryId == null)
        {
            MyViewModel MyViewModelProduct = new MyViewModel();
            Product? Temporal = _context.Products
                .Include(p => p.Association)
                    .ThenInclude(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
            List<Category>? TemporalCategory = _context.Categories
                .Where(c => !c.Associationn.Any(p => p.ProductId == id))
                .ToList();
            if (Temporal != null && TemporalCategory != null)
            {
                MyViewModelProduct.Categories = TemporalCategory;
                MyViewModelProduct.Product = Temporal;
                ModelState.AddModelError("ProductId", "Product is required!");
                return View("ViewProduct", MyViewModelProduct);
            }
        }
        Product product = new Product();
        product = Temp;
        Category? categorytemp = _context.Categories.Find(CategoryId);
        
        if (categorytemp != null)
        {
            product.Association.Add(new Association { Product = product, Category = categorytemp });
            //product.Association.Add(categorytemp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpGet("category")]
    public IActionResult Category()
    {
        CategoryViewModel categoryView = new CategoryViewModel();
        categoryView.Categories = _context.Categories.ToList();
        return View("Category", categoryView);
    }

    [HttpPost("category/create")]
    public IActionResult CreateCategory([Bind(Prefix = "CreateCategory")]Category NewCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(NewCategory);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
        else
        {
            CategoryViewModel categoryView = new CategoryViewModel();
            categoryView.Category = NewCategory;
            categoryView.Categories = _context.Categories.ToList();
            return View("Category", categoryView);
        }
    }
    [HttpGet("category/{id}")]
    public IActionResult ViewCategory(int id)
    {
        MyViewModelCategory myViewModelCategory = new MyViewModelCategory();
        var Temporal_category = _context.Categories
            .Include(c => c.Associationn)
            .FirstOrDefault(c =>c.CategoryId ==id); 
        var Temporal_product = _context.Products
            .Where(p => !p.Association.Any(c => c.CategoryId == id))
            .ToList();
        if (Temporal_category != null && Temporal_product != null)
        {
            myViewModelCategory.Products = Temporal_product;
            myViewModelCategory.Category = Temporal_category;
            return View("ViewCategory", myViewModelCategory);
        }
        else
        {
            return RedirectToAction("Category");
        }
    }

    [HttpPost("category/{id}/add")]
    public IActionResult AddProduct (int id, int? ProductId)
    {
        var Temporal = _context.Categories.FirstOrDefault(f => f.CategoryId == id);
        if (Temporal == null)
        {
            return RedirectToAction("Category");
        }
        if (ProductId == null)
        {
            MyViewModelCategory myViewModelCategory = new MyViewModelCategory();
            var Temp = _context.Categories
                .Include(c => c.Associationn)
                .FirstOrDefault(c => c.CategoryId == id);
            var Temp_Product = _context.Products
                .Where(p => !p.Association.Any(c => c.CategoryId == id))
                .ToList();
            if (Temp != null && Temp_Product != null)
            {
                myViewModelCategory.Products = Temp_Product;
                myViewModelCategory.Category = Temp;
                ModelState.AddModelError("ProductId", "Product is required!");
                return View("Category", myViewModelCategory);
            }
        }
        Category category = new Category();
        category = Temporal;
        Product? product = _context.Products.Find(ProductId);
        if (product != null)
        {
            category.Associationn.Add(new Association { Product = product, Category = category});
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
        else
        {
            return RedirectToAction("Category");
        }
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
