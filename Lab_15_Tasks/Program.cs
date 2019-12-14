using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
   

namespace Lab_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //Inside can go a delegate or anonymous method using Lambda

            var task01 = new Task(
            () => { }                   //lambda anonymous method
            );

            var task02 = new Task(
            () => { Console.WriteLine("In Task 02"); }
            );
            task02.Start();

            //slicker way
            var task03 = Task.Run(() => { Console.WriteLine("In task 03"); });
            var task04 = Task.Run(() => { Console.WriteLine("In task 04"); });
            var task05 = Task.Run(() => { Console.WriteLine("In task 05"); });

            //stopwatch

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();

        }
    }
}
