using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web_app_gcd.Models;

namespace web_app_gcd.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<Chapter> Chapters { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<DocumentCategory> DocumentCategories { get; set; }
    
}

