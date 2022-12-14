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
    public class DeleteModel : PageModel
    {
        private readonly Streamed_Chaos.Data.ApplicationDbContext _context;

        public DeleteModel(Streamed_Chaos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserPlaylist UserPlaylist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserPlaylists == null)
            {
                return NotFound();
            }

            var userplaylist = await _context.UserPlaylists.FirstOrDefaultAsync(m => m.Id == id);

            if (userplaylist == null)
            {
                return NotFound();
            }
            else 
            {
                UserPlaylist = userplaylist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserPlaylists == null)
            {
                return NotFound();
            }
            var userplaylist = await _context.UserPlaylists.FindAsync(id);

            if (userplaylist != null)
            {
                UserPlaylist = userplaylist;
                _context.UserPlaylists.Remove(UserPlaylist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
