using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketParsApp.Data.Models
{
    internal class PcCase
    {
        public int Id { get; set; }
        public string Manufacture { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string CaseFormat { get; set; } = string.Empty;
        public string BoardFormat { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Mass { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
