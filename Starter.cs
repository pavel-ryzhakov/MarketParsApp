using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketParsApp.Data.DataBase;
using Spectre.Console;
using AngleSharp.Html;
using AngleSharp.Html.Dom;
using AngleSharp;
using AngleSharp.Browser;
using System.Diagnostics;
using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Data.SqlTypes;
using static System.Net.WebRequestMethods;
using Table = Microsoft.EntityFrameworkCore.Metadata.Internal.Table;


namespace MarketParsApp
{
    public class Starter
    {
        
       
        IConfiguration _configuration;
        IBrowsingContext _context;
        private string _catalogurl = "https://tula.nix.ru/price.html?section=cpu_all#c_id=161&fn=161&g_id=7&page=1&sort=%2Bp8175%2B1605%2B7287%2B766%2B2326&spoiler=&store=region-1483_0&thumbnail_view=2";
        public Starter()

        {
            
            _configuration = Configuration.Default.WithDefaultLoader().WithLocaleBasedEncoding();
            _context = BrowsingContext.New(_configuration);
            
        }


        public async Task<int> StartAsync()
        {
            AnsiConsole.WriteLine("Start");
            
            return 0;
        }




        public async IAsyncEnumerable<string> PushList()
        {

            var doc = await _context.OpenAsync(_catalogurl);
            var selector = "a.t";
            var cells = doc.QuerySelectorAll(selector).OfType<IHtmlAnchorElement>();
            var titles = cells.Select(m => m.Href).ToList();


            foreach (var title in titles)
            { 
                 yield return title;
                

            }


        }




        
    }
}

    

