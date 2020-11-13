using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstSample_With_RazorPages.Models
{
    public class FootballClub
    {
        public int Id { get; set; } // Auto-Properties

        public string Clubname { get; set; }

        public int Budget { get; set; }

        public int StadiumSize { get; set; }
    }
}
