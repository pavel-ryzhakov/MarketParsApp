using MarketParsApp.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Spectre.Console;
using MarketParsApp.Data;
using MarketParsApp.Data.Models;
using MarketParsApp.Parser;

namespace MarketParsApp
{
    internal class Program
    {


        
        static async Task<int> Main(string[] args)
        {


            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((
                    ctx, services) => // ctx 
                {
                    
                    
                    services.AddDbContext<DataBaseContext>(options =>
                        options.UseNpgsql(
                            ("server=localhost;username=postgres;database=MarketParserTest1;password=131313")));
                    services.AddScoped<Starter>();
                    services.AddScoped<CpuParser>();

                });



            var app = builder.Build();
            

            var onn = await app.Services.GetRequiredService<Starter>().StartAsync();
            var productUrl = app.Services.GetRequiredService<Starter>().PushList();
            List<string> productsUrlList = await productUrl.ToListAsync();


            var concreteProс = app.Services.GetRequiredService<CpuParser>().StartParse(productsUrlList);
            List<Processor> concreteProсList = await concreteProс.ToListAsync();

            var concreteMoth = app.Services.GetRequiredService<MotherboardParser>().StartParse(productsUrlList);
            List<Motherboard> concreteMothList = await concreteMoth.ToListAsync();






            foreach (var VARIABLE in concreteProсList)
            {
                AnsiConsole.WriteLine(VARIABLE.Model);
            }


            var table = new Spectre.Console.Table();
            table.Title = new TableTitle("[underline yellow]Процессоры[/]");

            await AnsiConsole.Live(table)
                .StartAsync(
                    async ctx =>
                    {
                        table.AddColumn("Производитель");
                        ctx.Refresh();
                        table.AddColumn("Модель");
                        ctx.Refresh();
                        table.AddColumn("К-во ядер");
                        ctx.Refresh();
                        table.AddColumn("Частота");
                        ctx.Refresh();
                        table.AddColumn("К-во потоков");
                        ctx.Refresh();
                        table.AddColumn("Сокет");
                        ctx.Refresh();
                        table.AddColumn("Масса");
                        ctx.Refresh();
                        table.AddColumn(new TableColumn(new Markup("[yellow]Цена,руб :shopping_cart: [/]")));
                        ctx.Refresh();

                        foreach (var product in concreteProсList)
                        {
                            string man = product.Manufacture.ToString();
                            string mod = product.Model.ToString();
                            string cor = product.Cores.ToString();
                            string fre = product.Frequency;
                            string thr = product.Threads;
                            string soc = product.Socket;
                            string mas = product.Mass.ToString();
                            string pri = product.Price.ToString();

                            table.AddRow(man, mod, cor, fre, thr, soc, mas, pri);
                            ctx.Refresh();
                            await Task.Delay(30);
                        }
                    });
            return onn;


        }
    }
}



        




        



    

