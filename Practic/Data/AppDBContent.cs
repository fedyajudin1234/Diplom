using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practic.Data.Models;

namespace Practic.Data
{
    public class AppDBContent: IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            
        }
        public DbSet<Aim> Aim { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<AimItem> AimItems { get; set; }
        public DbSet<Compiler> Compilers { get; set; }
        public DbSet<CompilerDetail> CompilerDetails { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<AimImage> AimImages { get; set; }
    }
}
