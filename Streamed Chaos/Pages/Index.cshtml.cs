using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Streamed_Chaos.Data;
using Streamed_Chaos.Pages.Services;

namespace Streamed_Chaos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Streamed_Chaos.Data.ApplicationDbContext _context;

        public IndexModel(Streamed_Chaos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserPlaylist> UserPlaylist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserPlaylists != null)
            {
                UserPlaylist = await _context.UserPlaylists.ToListAsync();
            }
        }
    }
}
