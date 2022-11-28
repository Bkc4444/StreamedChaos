using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Streamed_Chaos.Data;
using Streamed_Chaos.Pages.Services;

namespace Streamed_Chaos.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Streamed_Chaos.Data.ApplicationDbContext _context;

        public CreateModel(Streamed_Chaos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserPlaylist UserPlaylist { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserPlaylists.Add(UserPlaylist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
