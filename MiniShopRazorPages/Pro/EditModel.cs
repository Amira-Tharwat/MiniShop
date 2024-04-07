using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniShopRazorPages.Data;
using MiniShopRazorPages.Models;

namespace MiniShopRazorPages.Pro
{
    public class EditModel(ApplicationDbContext _db):PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            if(id!=null && id != 0)
            {
                Product = _db.products.SingleOrDefault(m => m.Id == id);
            }
        }
        public IActionResult OnPost()
        {
            _db.products.Update(Product);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
