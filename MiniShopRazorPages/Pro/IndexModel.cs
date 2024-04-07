using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazorPages.Data;
using MiniShopRazorPages.Models;

namespace MiniShopRazorPages.Pro
{
    public class IndexModel(ApplicationDbContext _db):PageModel
    {
        public List<Product> products = new List<Product>();
        public void OnGet() 
        {
            products=_db.products.ToList();
        }
        public IActionResult OnGetDelete(int id)
        {
            var product =_db.products.SingleOrDefault(m=>m.Id == id);
            if(product != null)
            {
                _db.products.Remove(product);
                _db.SaveChanges();
                return  RedirectToPage("Index");
            }
            return Page();
        }
    }
}
