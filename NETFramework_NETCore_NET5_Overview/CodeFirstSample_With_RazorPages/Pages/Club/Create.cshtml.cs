using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodeFirstSample_With_RazorPages.Data;
using CodeFirstSample_With_RazorPages.Models;

namespace CodeFirstSample_With_RazorPages.Pages.Club
{
    public class CreateModel : PageModel
    {
        private readonly CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext _context;

        public CreateModel(CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FootballClub FootballClub { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FootballClub.Add(FootballClub);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
