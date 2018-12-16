using System;
using System.Collections.Generic;

namespace HwyApi.Models
{
    public partial class Testmap
    {
        public int Testid { get; set; }
        public string Obj { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
