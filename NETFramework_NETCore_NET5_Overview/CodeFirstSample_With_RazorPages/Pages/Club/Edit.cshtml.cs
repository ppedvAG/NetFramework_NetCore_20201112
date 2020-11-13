using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstSample_With_RazorPages.Data;
using CodeFirstSample_With_RazorPages.Models;

namespace CodeFirstSample_With_RazorPages.Pages.Club
{
    public class EditModel : PageModel
    {
        private readonly CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext _context;

        public EditModel(CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FootballClub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballClubExists(FootballClub.Id))
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

        private bool FootballClubExists(int id)
        {
            return _context.FootballClub.Any(e => e.Id == id);
        }
    }
}
