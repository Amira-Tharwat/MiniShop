using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MiniShopRazorPages.Data;
using MiniShopRazorPages.Models;

namespace MiniShopRazorPages.Comp
{
    public class EditModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company Company { get; set; }
        public void OnGet(int id)
        {
            if (id != null && id != 0)
            {
                Company = _db.companies.SingleOrDefault(m => m.Id == id);
            }
        }
        public IActionResult OnPost()
        {
            _db.companies.Update(Company);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
