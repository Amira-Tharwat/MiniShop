using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazorPages.Data;
using MiniShopRazorPages.Models;

namespace MiniShopRazorPages.Pro
{
    public class CreateModel(ApplicationDbContext _db):PageModel
    {
        [BindProperty]
        public Product product {  get; set; }
        public IActionResult OnGet()
        {
            return Page();

        }
        public IActionResult OnPost()
        {
            _db.products.Add(product);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
