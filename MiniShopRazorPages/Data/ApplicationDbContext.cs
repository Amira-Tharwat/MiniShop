using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniShopRazorPages.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MiniShopRazorPages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
