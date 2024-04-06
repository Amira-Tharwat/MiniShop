using Microsoft.AspNetCore.Mvc;
using MiniShop.Data;
using MiniShop.Models;
using MiniShop.NewViewModel;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MiniShop.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<BlogType> _BlogTypes = new List<BlogType>();
        private static List<Company> _companies = new List<Company>();
        private readonly ApplicationDbContext _db;
        public DashBoardController(ApplicationDbContext db)
        {
            _db = db;
            _companies.Add(new Company { Id = 1, Name = "nike" });
            _companies.Add(new Company { Id = 2, Name = "adidas" });

            _BlogTypes.Add(new BlogType { Id = 1, Name = "comedy" });
            _BlogTypes.Add(new BlogType { Id = 2, Name = "romantic" });
            _BlogTypes.Add(new BlogType { Id = 3, Name = "horror" });
            _BlogTypes.Add(new BlogType { Id = 4, Name = "scientific" });

        }
        public IActionResult Index()
        {
            return View();
        }

        #region AddProduct
        public IActionResult AddProduct()
        {
            var co = _db.companies.ToList();
            var ProductView = new ProductViewModel()
            {
                Company = co
            };
            return View(ProductView);

        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var co = _db.companies.ToList();
            var ProductView = new ProductViewModel()
            {
                Company = co
            };
            if (!ModelState.IsValid)
            {
                return View(ProductView);
            }
            _db.products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        #endregion

        #region ViewProducts
        public IActionResult ViewProducts()
        {

            var Product = _db.products.Include(p => p.company).ToList();
            return View(Product);
        }

        #endregion

        #region DeleteProduct
        public IActionResult Delete(int id)
        {
            Product? product = _db.products.FirstOrDefault(x => x.Id == id);
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("ViewProducts");
        }

        #endregion

        #region EditProduct
        public IActionResult EditProduct(int id)
        {
            var coms = _db.companies.ToList();
            var p = new ProductViewModel()
            {
                Company = coms
            };
            p.Product = _db.products.FirstOrDefault(y => y.Id == id);

            return View(p);
        }
        [HttpPost]

        public IActionResult EditProduct(Product product)
        {

            Product newProduct = _db.products.FirstOrDefault(x => x.Id == product.Id);
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.EnableSize = product.EnableSize;
            newProduct.CompanyId = product.CompanyId;
            newProduct.Quantity = product.Quantity;
            _db.products.Update(newProduct);
            _db.SaveChanges();
            return RedirectToAction("index");
        }


        #endregion

        #region AddBlog
        public IActionResult AddBlog()
        {
            var types = _db.blogTypes.ToList();
            var BlogView = new BlogViewModel()
            {
                types = types
            };
            return View(BlogView);
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            var types = _db.blogTypes.ToList();
            var BlogView = new BlogViewModel()
            {
                types = types
            };
            if (!ModelState.IsValid)
            {
                return View(BlogView);
            }
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
        #endregion

        #region ViewBlogs

        public IActionResult ViewBlogs()
        {

            var blog = _db.blogs.Include(p => p.BlogType).ToList();
            return View(blog);
        }


        #endregion

        #region DeleteBlog
        public IActionResult DeleteBlog(int id)
        {
            Blog? blog = _db.blogs.FirstOrDefault(x => x.Id == id);
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return RedirectToAction("ViewBlogs");
        }

        #endregion

        #region EditBlog
        public IActionResult EditBlog(int id)
        {
            var types = _db.blogTypes.ToList();
            var t = new BlogViewModel()
            {
                types = types
            };
            t.blog = _db.blogs.FirstOrDefault(y => y.Id == id);

            return View(t);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Blog newBlog = _db.blogs.FirstOrDefault(x => x.Id == blog.Id);
            newBlog.Name = blog.Name;
            newBlog.Description = blog.Description;
            newBlog.AuthorName = blog.AuthorName;
            newBlog.BlogTypeId = blog.BlogTypeId;
            _db.blogs.Update(newBlog);
            _db.SaveChanges();

            return RedirectToAction("index");

        }
        #endregion


    }
}
