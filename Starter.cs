
using Spectre.Console;
using AngleSharp.Html.Dom;
using AngleSharp;



namespace MarketParsApp
{
    public class Starter
    {
        
       
        public IConfiguration _configuration;
        public IBrowsingContext _context;
       
        public Starter()

        {
            
            _configuration = Configuration.Default.WithDefaultLoader().WithLocaleBasedEncoding();
            _context = BrowsingContext.New(_configuration);
            
        }


        public async Task<int> StartAsync()
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Markup($"[white on black]Приложение запущено[/]" + Emoji.Known.Window);
            AnsiConsole.WriteLine();

            return 0;
        }




        public async IAsyncEnumerable<string> PushList(string catalogurl)
        {


            var doc = await _context.OpenAsync(catalogurl);
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

    

