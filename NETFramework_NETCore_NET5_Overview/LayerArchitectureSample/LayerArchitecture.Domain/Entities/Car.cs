using System;
using System.Collections.Generic;

namespace LayerArchitecture.Domain.Entities
{
    public partial class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ConstructYear { get; set; }
        public string Farbe { get; set; }
        public bool? IsCaprio { get; set; }
        public bool? MitRadio { get; set; }
    }
}
