using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Streamed_Chaos.Models;
using Streamed_Chaos.Pages.Services;

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

        public DbSet<UserPlaylist> UserPlaylists { get; set; }

        public DbSet<Streamed_Chaos.Pages.Services.UserPlaylistVm> UserPlaylistVm { get; set; }
    }
}