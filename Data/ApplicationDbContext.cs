using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CAVWAApp.Models;

namespace CAVWAApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppEvent> AppEvent { get; set; } = default!;

        public DbSet<ApplicationUserMod> UserMods { get; set; } = default!;
    }
}