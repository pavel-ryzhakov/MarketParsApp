using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using AngleSharp;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MarketParsApp.Data.DataBase;
using MarketParsApp.Data.Models;
using Flurl;
using AngleSharp.Dom;
using Spectre.Console;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Table = Spectre.Console.Table;
using Flurl.Http;
namespace MarketParsApp.Parser
{
    internal class ProcessorParser
    {
        IConfiguration _configuration;
        public readonly IBrowsingContext _context;
        public readonly IDbContextFactory<DataBaseContext> _contextFactory;
        public Table _table;
        public int _count;
        public string voidUrl = "https://static.nix.ru/art/picture_coming_soon.gif";



        public ProcessorParser(IDbContextFactory<DataBaseContext> contextFactory)
        {
            _configuration = Configuration.Default.WithDefaultLoader().WithLocaleBasedEncoding();
            _context = BrowsingContext.New(_configuration);
            _contextFactory = contextFactory;
        }


        public async Task StartParse(List<string> products)

        {
            using var context = _contextFactory.CreateDbContext();
            _table = new Spectre.Console.Table();
            await AnsiConsole.Live(_table)
                .StartAsync(
                    async ctx =>
                    {
                        _table.Title = new TableTitle("Процессоры");
                        _table.Border = TableBorder.HeavyHead;
                        _table.AddColumn(new TableColumn(new Markup("[blue]Производитель [/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Модель[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]К-во ядер[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Частота[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]К-во потоков[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Сокет[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Цена(руб.)[/]" + Emoji.Known.MoneyWithWings)));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Фото[/]")));
                        ctx.Refresh();
                        _count = 0;


                        foreach (var product in products)
                        {
                            var doc = await _context.OpenAsync(product);
                            Processor entity = new Processor();

                            try
                            {
                                entity.Manufacture = doc.QuerySelector("td#tdsa2943").FirstChild.TextContent.Trim();
                                entity.Model = doc.QuerySelector("td#tdsa2944 ").FirstChild.TextContent ?? "n/a";
                                entity.Price =
                                    Int32.Parse(doc.QuerySelector("meta[itemprop=price]").GetAttribute("content"));
                                entity.Cores = Int32.Parse(doc.QuerySelector("td#tdsa2557 ").FirstChild.TextContent); 
                                entity.Frequency = doc.QuerySelector("td#tdsa3808").FirstChild.TextContent;
                                entity.Threads = doc.QuerySelector("td#tdsa23450").FirstChild.TextContent ?? "n/a";

                                string socket = doc.QuerySelector("td#tdsa1307").FirstChild.TextContent;
                                int socind = socket.IndexOf("Socket");
                                entity.Socket = socket.Remove(0, socind + 7);

                                string imgurl = doc.GetElementById("goods_photo").GetAttribute("href");
                                if (imgurl == voidUrl) { throw new Exception(); }
                                string name = entity.GetType().Name;
                                string path = $@"C:\Development\HardWareGenius\Data\Images\Hardware\{name}\{entity.Manufacture}";
                                entity.Image = await imgurl.DownloadFileAsync(path);

                                string tb1 = entity.Manufacture;
                                string tb2 = entity.Model;
                                string tb3 = entity.Cores.ToString();
                                string tb4 = entity.Frequency;
                                string tb5 = entity.Threads;
                                string tb6 = entity.Socket;
                                string tb7 = entity.Price.ToString();
                                string tb8 = entity.Image;
                                _table.AddRow(tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8);
                                ctx.Refresh();


                                await context.Processors.AddAsync(entity);
                                _count++;
                                await Task.Delay(100);
                            }

                            catch (Exception e)
                            {
                                continue;
                            }

                        }


                    });


            AnsiConsole.WriteLine();
            AnsiConsole.Markup("[default on grey] найдено единиц товаров [/]");
            AnsiConsole.Markup($"[white on green] {_count} [/]");
            AnsiConsole.WriteLine();
            var loading = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]загрузить найденные позиции в базу данных?[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Да", "Нет",
                    }));

            if (loading == "Да")
            {
                await AnsiConsole.Status()
                    .StartAsync("[green]Сохранение...[/]", updateResults => context.SaveChangesAsync());

            }
        }
    }
}
