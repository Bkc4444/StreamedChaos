using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Streamed_Chaos.Models;

namespace Streamed_Chaos.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //This is adding whats in ApplicationUsers to the database
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}