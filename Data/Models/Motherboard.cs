using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace MarketParsApp.Data.Models
{
    internal class Motherboard 
    {
        public int Id { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public string Chipset { get; set; }
        public string BoardFormat { get; set; } = string.Empty;
        public string DdrType { get; set; } = string.Empty;
        public int DdrSum { get; set; }
        public string Socket { get; set; } = string.Empty;
        //public string Size { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Image { get; set; }

 
    }
}
