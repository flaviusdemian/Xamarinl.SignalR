using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SignalRDemo.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9876"))
            {
                Console.WriteLine("Hubs running...");
                Console.ReadLine();
            }
        }
    }
}
