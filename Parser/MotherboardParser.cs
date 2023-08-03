using AngleSharp.Html.Dom;
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

namespace MarketParsApp.Parser
{

    internal class MotherboardParser
    {

        IConfiguration _configuration;
        IBrowsingContext _context;
        internal DataBaseContext _data;
        //private string sel = "td#tdsa";
        private List<string> _products;
        //public Spectre.Console.Table Table;


        public MotherboardParser(DataBaseContext data)
        {

            _configuration = Configuration.Default.WithDefaultLoader().WithLocaleBasedEncoding();
            _context = BrowsingContext.New(_configuration);
            // ---------------нужно ли???
            
            
                    
        }

        //await AnsiConsole.Progress()
        //    .StartAsync(async ctx =>
        //{
        //    // Define tasks
        //    var task1 = ctx.AddTask("[green]Chrome RAM usage[/]");
        //    var task2 = ctx.AddTask("[yellow]VS Code RAM usage[/]");

        //    while (!ctx.IsFinished)
        //    {
        //        // Simulate some work
        //        await Task.Delay(100);

        //        // Increment
        //        task1.Increment(4.5);
        //        task2.Increment(2);
        //    }
        //});




        public async IAsyncEnumerable<Motherboard> StartParse(List<string> products)

        {

            //var table = new Spectre.Console.Table();


            ////table.Title = new TableTitle("[underline yellow]Процессоры[/]");



            //await AnsiConsole.Live(table)
            //    .StartAsync(
            //        async ctx =>
            //        {
            //            table.AddColumn("Производитель"); 
            //            ctx.Refresh();
            //            table.AddColumn("Модель");
            //            ctx.Refresh();
            //            table.AddColumn("К-во ядер");
            //            ctx.Refresh();
            //            table.AddColumn("Частота");
            //            ctx.Refresh();
            //            table.AddColumn("К-во потоков");
            //            ctx.Refresh();
            //            table.AddColumn("Сокет");
            //            ctx.Refresh();
            //            table.AddColumn("Масса");
            //            ctx.Refresh();
            //            table.AddColumn(new TableColumn(new Markup("[yellow]Цена,руб[/]")));
            //            ctx.Refresh();

                        foreach (var product in products)
                        {

                            var doc = await _context.OpenAsync(product);

                            
                            Motherboard entity = new Motherboard(doc);


                                try
                            {
                                
                                entity.BoardFormat = doc.QuerySelector("td#tdsa2557 ").FirstChild.TextContent;

                                entity.DdrType = doc.QuerySelector("td#tdsa3808").FirstChild.TextContent ?? "n/a";

                                string ddrsum = doc.QuerySelector("td#tdsa1672").FirstChild.TextContent;
                                entity.DdrSum = Int32.Parse(Regex.Replace(ddrsum, @"\D+", "", RegexOptions.ECMAScript));

                                entity.Socket = doc.QuerySelector("td#tdsa2557 ").FirstChild.TextContent;

                                entity.Size = doc.QuerySelector("td#tdsa2557 ").FirstChild.TextContent;
                    
                            }

                            catch (Exception e)
                            {

                                AnsiConsole.WriteLine($"Ошибочка вышла! {e}");

                                continue;

                            }
                            
                            

                            
                            //await _data.Processors.AddAsync(entity);
                            yield return entity;

                            



                        }

                    }
            
                    //AnsiConsole.WriteLine("Добавить полученные товары в базу данных?");
                    //if ()
                    //await _data.SaveChangesAsync();
                    //AnsiConsole.MarkupLine("Hello :globe_showing_europe_africa:!");
        }
        
        //foreach (var product in products)
            //{

            //    var doc = await _context.OpenAsync(product);
            //    Processor entity = new Processor();
            //    entity.Manufacture = doc.QuerySelector("td#tdsa2943").FirstChild.TextContent ?? "n/a";
            //    entity.Model = doc.QuerySelector("td#tdsa2944 ").FirstChild.TextContent ?? "n/a";

            //    try
            //    {
            //        entity.Cores = sbyte.Parse(doc.QuerySelector("td#tdsa2557 ").FirstChild.TextContent);
            //    }
            //    catch (Exception e)
            //    {

            //        Console.WriteLine(e);
            //        continue;

            //    }

            //    string freq = doc.QuerySelector("td#tdsa2943").FirstChild.TextContent ?? "n/a";
            //    entity.Frequency = Regex.Replace(freq, @"\D+.{4}", "", RegexOptions.ECMAScript);
            //    entity.Threads = doc.QuerySelector("td#tdsa23450").FirstChild.TextContent ?? "n/a";
            //    entity.Socket = doc.QuerySelector("td#tdsa1307").FirstChild.TextContent ?? "n/a";

            //    try
            //    {
            //        string mass = doc.QuerySelector("td#tdsa1672").FirstChild.TextContent;
            //        entity.Mass = float.Parse(Regex.Replace(mass, @"\D+", "", RegexOptions.ECMAScript));
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        continue;
            //    }


            //    try
            //    {
            //        entity.Price = Int32.Parse(doc.QuerySelector("meta[itemprop=price]").GetAttribute("content"));
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        entity.Price = 0;
            //    }


            //try
            //{
            //    var cells = doc.QuerySelectorAll("a#goods_photo").OfType<IHtmlAnchorElement>();
            //    var imageRef = cells.Select(m => m.Href).ToString();
            //    entity.Image = cells.Select(m => m.Href).ToString();
            //    string a = entity.Manufacture + @"\" + entity.Model;
            //    string path = @"E:\Products\BuildGenius\Images\Cp";
            //    string subpath = $@"{a}";
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //        Console.WriteLine($"Папка {path} создана");
            //    }

            //    Directory.CreateDirectory($"{path}/{subpath}");

            //    string downloadpath = $"{path}/{subpath}";
            //    await imageRef.DownloadFileAsync(downloadpath);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}




        }


            

   

