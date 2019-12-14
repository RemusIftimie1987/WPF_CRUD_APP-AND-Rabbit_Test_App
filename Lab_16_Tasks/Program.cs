using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace Lab_16_Tasks
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            
            s.Start();
            var task01 = Task.Run(() =>
            {
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task01 completed at time {s.ElapsedMilliseconds}");
            }
            );

            // old fashioned way of putting a DELEGATE as a Parameter into a Task
            var actionDelegate = new Action(SpecialActionMethod); // pass in Method as Argument
            var task02 = new Task(actionDelegate);
            task02.Start();

            //array of tasks
            Task[] taskArray = new Task[]
            {
               new Task ( ()=>{// do a job eg overnight processing task
               }),
               new Task ( ()=>{}),
               new Task ( ()=>{}),
               new Task ( ()=>{}),
               new Task ( ()=>{}),
            };

            // Getting data back from tasks
            var TaskWithoutReturningData = new Task( () => { });
            var TaskWithReturningData = new Task<int>( () => {
                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    total += i;
                }
                return total;
            });
            TaskWithReturningData.Start();

            Console.WriteLine($"I have counted to 100 using a background task so I don't have" + $"to wait to  The answer is {TaskWithReturningData.Result}" );

            //second way
            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run (() => {
                Thread.Sleep(500);
                Console.WriteLine($"Array Task 0 completing at {s.ElapsedMilliseconds}");
            });
            taskArray2[1] = Task.Run(() => {
                Thread.Sleep(500);
                Console.WriteLine($"Array Task 1 completing at {s.ElapsedMilliseconds}");
            });
            taskArray2[2] = Task.Run(() => {
                Thread.Sleep(500);
                Console.WriteLine($"Array Task 2 completing at {s.ElapsedMilliseconds}");
            });

            //Wait for one or all array tasks to complete
            Task.WaitAny(taskArray2);
            Console.WriteLine($"Waiting for first Array Task to complete at {s.ElapsedMilliseconds}");
            //Wait for ALL
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for ALL Array Tasks {s.ElapsedMilliseconds}");

            //PARALLEL FOR LOOP
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //regular foreach is in order 1..2..3..4
            //parallel foreach just kicks off x jobs at the same time, wait for answers
            Parallel.ForEach(myCollection, (item) =>
            {   
              //  Thread.Sleep(item * 100);
                Console.WriteLine($"ForEach loop item {item} finishing at time { s.ElapsedMilliseconds}");

            });
            //var t = s.ElapsedMilliSeconds;
            //Contrast with sync loop
            Console.WriteLine("\n\nNow run as SYNC LOOP");
            foreach (var item in myCollection)
            {
              //  Thread.Sleep(item * 100);
                Console.WriteLine($"Sync foreach loop item {item} finishing at time { s.ElapsedMilliseconds}");
            }
           // Console.WriteLine($"Sync loop took { s.ElapsedMilliseconds-t} miliseconds to complete");


            Console.WriteLine($"Application has finished on time {s.ElapsedMilliseconds}");
            Console.WriteLine($"Application has finished on time {s.ElapsedTicks}");
            Console.Read();
            
            //Also powerful is parallel LINQ
            //Fake it here: Use local connection
            var databaseOutput =
                (from item in myCollection
                 select item).AsParallel().ToList();
            // could use this on real database query if many queries

        }

        static void SpecialActionMethod()
        {
            Console.WriteLine("These action method takes no parameters, returns nothing, but just" +
                "performs an action, in this case print out....");
            var total = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                total += i;
            }
            Console.WriteLine(total);
            //Thread.Sleep(2000);
            Console.WriteLine($"Special actiom Method completed at {s.ElapsedMilliseconds}");
        }

    }
}
