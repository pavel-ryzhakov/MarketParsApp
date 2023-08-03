using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace MarketParsApp.Data.Models
{
    internal class Motherboard : ParsePattern
    {

        public Motherboard(IDocument doc) : base()
        {
            base.doc = doc;
        }

        public static IDocument doc { get;  set; }
        public int Id { get; set; }
        public string BoardFormat { get; set; } = string.Empty;
        public string DdrType { get; set; } = string.Empty;
        public int DdrSum { get; set; }
        public string Socket { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        
    }
}
