using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MiniShopRazorPages.Data;
using MiniShopRazorPages.Models;

namespace MiniShopRazorPages.Comp
{
    public class IndexModel(ApplicationDbContext _db) : PageModel
    {
        public List<Company> companies = new List<Company>();
        public void OnGet()
        {
            companies = _db.companies.ToList();
        }
        public IActionResult OnGeTDelete(int id)
        {
            var company = _db.companies.SingleOrDefault(x => x.Id == id);
            if (company != null)
            {
                _db.companies.Remove(company);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
