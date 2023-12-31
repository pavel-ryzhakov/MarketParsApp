﻿using AngleSharp.Html.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Internal;
using Flurl.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarketParsApp.Parser
{

    internal class MotherboardParser
    {

        IConfiguration _configuration;
        public readonly IBrowsingContext _context;
        public readonly IDbContextFactory<DataBaseContext> _contextFactory;
        public Table _table;
        public int _count ;
        public string voidUrl = "https://static.nix.ru/art/picture_coming_soon.gif";


        public MotherboardParser(IDbContextFactory<DataBaseContext> contextFactory)
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
                        _table.Border = TableBorder.HeavyHead;
                        _table.AddColumn(new TableColumn(new Markup("[blue]Производитель [/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Модель[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Чипсет[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Формат[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Тип памяти[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Макс.памяти[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Сокет[/]")));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Цена (руб.)[/]" + Emoji.Known.MoneyWithWings)));
                        ctx.Refresh();
                        _table.AddColumn(new TableColumn(new Markup("[blue]Фото[/]")));
                        ctx.Refresh();
                        _count = 0;



                        foreach (var product in products)
                        {
                            var doc = await _context.OpenAsync(product);
                            Motherboard entity = new Motherboard();


                            try
                            {
                                entity.Manufacture = doc.QuerySelector("td#tdsa2943").FirstChild.TextContent.Trim();
                                entity.Model = doc.QuerySelector("td#tdsa2944 ").FirstChild.TextContent ?? "n/a";
                                entity.Price = 
                                    Int32.Parse(doc.QuerySelector("meta[itemprop=price]").GetAttribute("content"));

                               
                                
                                
                                string format =  doc.QuerySelector("td#tdsa643 ").FirstChild.TextContent;
                                int formind = format.IndexOf("ATX");
                                entity.BoardFormat= format.Substring(0, formind + 3);

                                entity.Chipset = doc.QuerySelector("td#tdsa3362").FirstChild.TextContent;

                                string type = doc.QuerySelector("td#tdsa642").FirstChild.TextContent;
                                entity.DdrType = type.Remove(4);

                                string ddrsum = doc.QuerySelector("td#tdsa894").FirstChild.TextContent;
                                entity.DdrSum =
                                    Int32.Parse(Regex.Replace(ddrsum, @"\D+.{4}", "", RegexOptions.ECMAScript));

                                string socket = doc.QuerySelector("td#tdsa1307").FirstChild.TextContent;
                                int socind = socket.IndexOf("Socket");
                                entity.Socket = socket.Remove(0, socind+7);

                                string imgurl = doc.GetElementById("goods_photo").GetAttribute("href");
                                if (imgurl == voidUrl) { throw new Exception(); }
                                string name = entity.GetType().Name;
                                string path = $@"C:\Development\HardWareGenius\Data\Images\Hardware\{name}\{entity.Manufacture}";
                                entity.Image = await imgurl.DownloadFileAsync(path, $"{entity.Model}_{entity.GetHashCode()}.jpg");

                                string man = entity.Manufacture.ToString();
                                string mod = entity.Model.ToString();
                                string cps = entity.Chipset;
                                string frm = entity.BoardFormat;
                                string ddr = entity.DdrType;
                                string max = entity.DdrSum.ToString();
                                string soc = entity.Socket;
                                string prc = entity.Price.ToString();
                                string jpg = entity.Image;
                                
                                
                                _table.AddRow(man, mod, cps, frm, ddr, max, soc, prc, jpg);
                                ctx.Refresh();
                                await context.Motherboards.AddAsync(entity);
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
    


















    

                    
            
                
