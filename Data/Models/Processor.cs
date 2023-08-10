using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace MarketParsApp.Data.Models
{
    internal class Processor

    {
        public int Id { get; set; }
        public string Manufacture { get; set; } 
        public string Model { get; set; } 
        public int Cores { get; set; }
        public string Frequency { get; set; } 
        public string Threads { get; set; } 
        public string Socket { get; set; } 
        //public string Size { get; set; } 
        //public float Mass { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } 
        
    }
}
