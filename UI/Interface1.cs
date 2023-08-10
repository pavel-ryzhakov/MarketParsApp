using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketParsApp.UI
{
    internal interface ITableinterface1
    {
        public string Manufacture { get; set; }

        public string Model { get; set; }

        public int Mass { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

    }
}
