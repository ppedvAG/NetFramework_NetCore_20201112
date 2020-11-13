using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeFirstSample_With_RazorPages.Data;
using CodeFirstSample_With_RazorPages.Models;

namespace CodeFirstSample_With_RazorPages.Pages.Club
{
    public class DeleteModel : PageModel
    {
        private readonly CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext _context;

        public DeleteModel(CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FootballClub FootballClub { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FootballClub = await _context.FootballClub.FirstOrDefaultAsync(m => m.Id == id);

            if (FootballClub == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FootballClub = await _context.FootballClub.FindAsync(id);

            if (FootballClub != null)
            {
                _context.FootballClub.Remove(FootballClub);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
