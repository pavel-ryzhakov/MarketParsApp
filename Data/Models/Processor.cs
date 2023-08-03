﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketParsApp.Data.Models
{
    internal class Processor

    {
        public int Id { get; set; }
        public string Manufacture { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Cores { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public string Threads { get; set; } = string.Empty;
        public string Socket { get; set; } = string.Empty;
        //public string Size { get; set; } = string.Empty;
        public float Mass { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
