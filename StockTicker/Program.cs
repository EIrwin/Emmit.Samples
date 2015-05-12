using System;
using Emmit;
using Microsoft.Owin.Hosting;

namespace StockTicker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = "http://localhost:8181";
            using (WebApp.Start<EmmitStartup>(url))
            {
                Console.WriteLine("Emmit server started on:" + url);
                Console.WriteLine("Select an option from the menu:");
                Console.WriteLine("a) Open Stock Market ");
                Console.WriteLine("b) Close Stock Market");
                Console.WriteLine("c) Update Stock Market");
                Console.WriteLine("d) Exit");

                IEmitterFactory factory = new EmitterFactory();
                IStockEmitter stockEmitter = factory.Create<StockEmitter>();

                bool done = false;
                while (done == false)
                {
                    var input = Console.ReadLine();

                    if (input == "d")
                    {
                        done = true;
                        Console.WriteLine("Exiting...");
                    }
                    if (input == "a")
                    {
                        stockEmitter.OnStockOpen();
                        Console.WriteLine("Stock market opened");
                    }   
                    if (input == "b")
                    {
                        stockEmitter.OnStockClosed();
                        Console.WriteLine("Stock market closed");
                    }
                    if (input == "c")
                    {
                        stockEmitter.OnStockUpdated(new StockUpdate()
                            {
                                Symbol = "ABC",
                                Value = new Random().Next(1, 100).ToString()
                            });

                        Console.WriteLine("Stock updated");
                    }
                }

            }
        }
    }
}
