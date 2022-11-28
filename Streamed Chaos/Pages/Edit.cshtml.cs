using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Streamed_Chaos.Data;
using Streamed_Chaos.Pages.Services;

namespace Streamed_Chaos.Pages
{
    public class EditModel : PageModel
    {
        private readonly Streamed_Chaos.Data.ApplicationDbContext _context;

        public EditModel(Streamed_Chaos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserPlaylist UserPlaylist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserPlaylists == null)
            {
                return NotFound();
            }

            var userplaylist =  await _context.UserPlaylists.FirstOrDefaultAsync(m => m.Id == id);
            if (userplaylist == null)
            {
                return NotFound();
            }
            UserPlaylist = userplaylist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserPlaylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPlaylistExists(UserPlaylist.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserPlaylistExists(int id)
        {
          return _context.UserPlaylists.Any(e => e.Id == id);
        }
    }
}
