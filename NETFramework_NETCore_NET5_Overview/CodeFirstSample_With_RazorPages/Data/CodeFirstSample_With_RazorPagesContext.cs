using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeFirstSample_With_RazorPages.Models;

namespace CodeFirstSample_With_RazorPages.Data
{
    public class CodeFirstSample_With_RazorPagesContext : DbContext
    {
        public CodeFirstSample_With_RazorPagesContext (DbContextOptions<CodeFirstSample_With_RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<CodeFirstSample_With_RazorPages.Models.FootballClub> FootballClub { get; set; }
    }
}
