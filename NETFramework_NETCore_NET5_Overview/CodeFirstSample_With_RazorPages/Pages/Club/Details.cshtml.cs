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
    public class DetailsModel : PageModel
    {
        private readonly CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext _context;

        public DetailsModel(CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext context)
        {
            _context = context;
        }

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
    }
}
