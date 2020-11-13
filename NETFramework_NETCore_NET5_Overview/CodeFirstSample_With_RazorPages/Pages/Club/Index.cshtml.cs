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
    public class IndexModel : PageModel
    {
        private readonly CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext _context;

        public IndexModel(CodeFirstSample_With_RazorPages.Data.CodeFirstSample_With_RazorPagesContext context)
        {
            _context = context;
        }

        public IList<FootballClub> FootballClub { get;set; }

        public async Task OnGetAsync()
        {
            FootballClub = await _context.FootballClub.ToListAsync();
        }
    }
}
