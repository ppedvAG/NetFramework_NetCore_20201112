using System;
using System.Collections.Generic;

#nullable disable

namespace CodeFirstSample_With_MVC.Models
{
    public partial class FootballClub
    {
        public int Id { get; set; }
        public string Clubname { get; set; }
        public int Budget { get; set; }
        public int StadiumSize { get; set; }
    }
}
