using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketParsApp.Data.Models
{
    internal class HardDisk/*:ParsePattern*/
    {   
        public int Id { get; set; }
        public string Manufacture { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string ReadSpeed { get; set; } = string.Empty;
        public string WriteSpeed { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        //public string Size { get; set; } = string.Empty;
        //public int Mass { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
