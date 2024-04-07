using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MiniShopRazorPages.Data;
using MiniShopRazorPages.Models;

namespace MiniShopRazorPages.Comp
{
    public class CreateModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company Company { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            _db.companies.Add(Company);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
