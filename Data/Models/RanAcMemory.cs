using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketParsApp.Data.Models
{
    internal class RanAcMemory
    {
        public int Id { get; set; }
        public string Manufacture { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string DdrType { get; set; } = string.Empty;
        public int DdrSum { get; set; }
        public int MemorySum { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public int Power { get; set; }
        //public string Size { get; set; } = string.Empty;
        public int Mass { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
