using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Spectre.Console;

namespace MarketParsApp.Data.Models
{
    internal class ParsePattern
    {
        
        public string Manufacture { get; set; } 

        public string Model { get; set; } 

        public int Mass { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } 
        public IDocument doc { get; set; }
        public ParsePattern()
        {
            try
            {
                Manufacture = doc.QuerySelector("td#tdsa2943").FirstChild.TextContent;
                Model = doc.QuerySelector("td#tdsa2944 ").FirstChild.TextContent ;
                string mass = doc.QuerySelector("td#tdsa1672").FirstChild.TextContent;
                Mass = Int32.Parse(Regex.Replace(mass, @"\D+", "", RegexOptions.ECMAScript));
                Price = Int32.Parse(doc.QuerySelector("meta[itemprop=price]").GetAttribute("content"));

            }
            catch(Exception ex) { AnsiConsole.WriteLine("Ошибка при инициализации");}
        

        }

    }
}
