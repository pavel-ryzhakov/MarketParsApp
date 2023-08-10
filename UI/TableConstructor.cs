using MarketParsApp.Data.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace MarketParsApp.Tables
//{
//    internal class TableConstructor
//    {
        
//        public TableConstructor()
//        {
            
//        }



//        public async Task CreateTable(List<ITableinterface1> productUrlList)
//        {
//            var table = new Spectre.Console.Table();
//            table.Title = new TableTitle("[underline yellow]Процессоры[/]");
            
//            await AnsiConsole.Live(table)
//                    .StartAsync(
//                        async ctx =>
//                        {
//                            table.AddColumn("Производитель");
//                            ctx.Refresh();
//                            table.AddColumn("Модель");
//                            ctx.Refresh();
//                            table.AddColumn("К-во ядер");
//                            ctx.Refresh();
//                            table.AddColumn("Частота");
//                            ctx.Refresh();
//                            table.AddColumn("К-во потоков");
//                            ctx.Refresh();
//                            table.AddColumn("Сокет");
//                            ctx.Refresh();
//                            table.AddColumn("Масса");
//                            ctx.Refresh();
//                            table.AddColumn(new TableColumn(new Markup("[yellow]Цена,руб :shopping_cart: [/]")));
//                            ctx.Refresh();
//                            //рефлексия
//                            foreach (var product in productUrlList)
//                            {
//                                typeof(prod)
//                                string man = product.Manufacture.ToString();
//                                string mod = product.Model.ToString();
//                                string cor = typeof.Cores.ToString();
//                                string fre = product.Frequency;
//                                string thr = product.Threads;
//                                string soc = product.Socket;
//                                string mas = product.Mass.ToString();
//                                string pri = product.Price.ToString();

//                                table.AddRow(man, mod, cor, fre, thr, soc, mas, pri);
//                                ctx.Refresh();
//                                await Task.Delay(30);
//                            }
//                        });
     
           
//    }
//}
