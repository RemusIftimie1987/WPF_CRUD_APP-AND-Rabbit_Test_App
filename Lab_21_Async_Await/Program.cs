using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Lab_21_Async_Await
{
    class Program
    {
        static Uri uri = new Uri("https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=netframework-4.8");
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            //Main method here
            // Sync Method: Wait for it
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1,Bob,21");
            File.AppendAllText("data.csv", "\n2,Tina,23");
            File.AppendAllText("data.csv", "\n3,Paul,24");
            //Wait for it
            //ReadDataSync();

            ////Async Method: Don't wait for it
            //ReadDataAsync();
            //Console.WriteLine("Code has finished");
            //Console.ReadLine();

            s.Start();
            GetWebPageSync();
            

            GetWebPageAsync();
            Console.WriteLine($"Code has finished at time{s.ElapsedMilliseconds}");
            Console.ReadLine();

        }

        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);
        }

         async static void ReadDataAsync()
        {
            var output = await File.ReadAllTextAsync("data.csv");
            Console.WriteLine("\naSync\n");
            Console.WriteLine(output);
        }

        static void GetWebPageSync()
        {
            // get the web page 
            
            var webclient = new WebClient { Proxy = null };
            webclient.DownloadFile(uri, @"c:\webpage\page01.html");
            Console.WriteLine($"Sync Web page has downloaded at time{s.ElapsedMilliseconds}");
            // start chrome and run it locally
        }
        async static void GetWebPageAsync()
        {
            //await
            var uri = new Uri("https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=netframework-4.8");

            var webclient = new WebClient { Proxy = null };
            var webpage = await webclient.DownloadStringTaskAsync(uri);
            Console.WriteLine($"Async Web page has downloaded at time{s.ElapsedMilliseconds}");

        }
    }
}
