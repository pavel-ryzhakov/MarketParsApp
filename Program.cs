using MarketParsApp.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Spectre.Console;
using MarketParsApp.Data;
using MarketParsApp.Data.Models;
using MarketParsApp.Parser;
using Microsoft.VisualBasic;

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

                 
                    services.AddDbContextFactory<DataBaseContext>(options =>
                        options.UseNpgsql(
                            ("server=localhost;username=postgres;database=MarketParserTest.v1;password=131313")));
                    services.AddScoped<Starter>();
                    services.AddScoped<ProcessorParser>();
                    services.AddScoped<MotherboardParser>();
                    services.AddScoped<GraphicCardParser>();
                    services.AddScoped<HardDiscParser>();
                    services.AddScoped<SolStateDriveParser>();
                    services.AddScoped<ProcessorCoolerParser>();
                    services.AddScoped<PowSuppUnitParser>();
                    services.AddScoped<RanAcMemoryParser>();
                    services.AddScoped<PcCaseParser>();


                });



            var app = builder.Build();

            var onn = await app.Services.GetRequiredService<Starter>().StartAsync();



            var start = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Выберите категорию комплектующих[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Процессоры", "Материнские платы","Видеокарты", "HDD", "SSD", "Охлаждение процессора",
                        "Блоки питания", "RAM","Корпус"
                    }));





            switch (start)
            {
                case "Процессоры":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог процессоров[/]");
                        var procUrlList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<ProcessorParser>().StartParse(procUrlList);
                        break;
                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "Процессоры";
                    }

                case "Материнские платы":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог материнских плат:[/]");
                        var motherboardsList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<MotherboardParser>().StartParse(motherboardsList);
                        break;
                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "Материнские платы";
                    }

                case "Видеокарты":
                    try
                    {
                        //    string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог видеокарт:[/]");

                        //    await app.Services.GetRequiredService<GraphicCardParser>().StartParse(app.Services.GetRequiredService<Starter>().PushList(url));
                        //    break;

                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог видеокарт:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<GraphicCardParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "Видеокарты";
                    }
                case "HDD":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог HDD:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<HardDiscParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "HDD";
                    }
                case "SSD":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог SSD:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<SolStateDriveParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "SSD";
                    }
                case "Охлаждение процессора":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог Кулеров:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<ProcessorCoolerParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "Охлаждение процессора";
                    }
                case "Блоки питания":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог БП:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<PowSuppUnitParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "Блоки питания";
                    }
                case "RAM":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог RAM:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<RanAcMemoryParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "RAM";
                    }
                case "Корпус":
                    try
                    {
                        string url = AnsiConsole.Ask<string>("[green]Введите ссылку на каталог корпусов:[/]");
                        var gcList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
                        await app.Services.GetRequiredService<PcCaseParser>().StartParse(gcList);
                        break;

                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.WriteException(ex = new ApplicationException("Введена некорректная ссылка! Повторите попытку."));
                        goto case "Корпус";
                    }
            }






            //Cpu parsing start
            //var productsUrl =  await app.Services.GetRequiredService<Starter>().PushList("https://tula.nix.ru/price.html?section=cpu_all#c_id=161&fn=161&g_id=7&page=1&sort=%2Bp8175%2B1605%2B7287%2B766%2B2326&spoiler=&store=region-1483_0&thumbnail_view=2").ToListAsync();
            //var procUrlList = await app.Services.GetRequiredService<Starter>().PushList(url).ToListAsync();
            //List<Processor> concreteProсList = await app.Services.GetRequiredService<CpuParser>().StartParse(procUrlList).ToListAsync();


            //motherboard parsing start
            //var motherboardsUrl = await app.Services.GetRequiredService<Starter>().
            //    PushList("https://tula.nix.ru/price.html?section=motherboards_biostar#c_id=102&enums%5B79%5D%5B%5D=6675&fn=916&g_id=759&page=all&sort=%2Bp8175%2B1011%2B1008%2B1769&spoiler=&store=region-1483_0&thumbnail_view=2").ToListAsync();
            //await app.Services.GetRequiredService<MotherboardParser>().StartParse(motherboardsUrl);

            AnsiConsole.Markup($"[blue1 on cyan3]Приложение завершило работу с кодом {onn}.[/]");
            return onn;


        }
    }
}



        




        



    

