//using Lab_09_Rabbit_Test;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_09_Rabbit_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Rabbit_Collection
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        #region RabbitGrowth*2+1
        public static (int cumulativeRabbitAge, int RabbitCount) MultiplyRabbits(int totalYears)
        {
            rabbits = new List<Rabbit>();
            #region InitializeRabbitListToHaveRabbitAge
            //first rabbit
            var rabbit0 = new Rabbit
            {
                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0
            };
            rabbits.Add(rabbit0);
            #endregion

            #region LoopThroughTheYears
            for (int year = 0; year < totalYears; year++)
            {
                #region ForEachRabbitGenerateANewOneAndAddOneYear
                // for each rabbit, generate a new one
                foreach (var rabbit in rabbits.ToArray())
                {
                    var newRabbit = new Rabbit();
                    rabbits.Add(newRabbit);
                    rabbit.Age++;
                }
                #endregion

            }
            #endregion

            #region SumRabbitAge
            int cumulativeRabbitAge = 0;
            rabbits.ForEach(r => cumulativeRabbitAge += r.Age);
            #endregion

            return (cumulativeRabbitAge, rabbits.Count);
        }
        #endregion
        //Homework / Stuff to do when you haven't got anithing to do
        // if their age is >=3
        //          Test data
        // Year 0    1 rabbit age 0
        // Year 1    1            1
        //      2    1            2
        //      3    1            3
        //      4    2            4,0
        //      5    3            5,1,0
        //      6    4            6,2,1,0
        //      7    5            7,3,2,1,0
        //      8    7            8,4,3,2,1,0,0  
        public static (int totalAge, int rabbitCount) MultiplyRabbitsAfterAgeThree(int totalYears)
        {
            rabbits = new List<Rabbit>();
            var rabbit0 = new Rabbit
            {
                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0
            };
            rabbits.Add(rabbit0);

            #region LoopThroughTheYears
            for (int year = 0; year < totalYears; year++)
            {
                #region ForEachRabbitGenerateANewOneAndAddOneYear
                // for each rabbit, generate a new one
                foreach (var rabbit in rabbits.ToArray())
                {
                    if (rabbit.Age >= 3)
                    {
                        var newRabbit = new Rabbit();
                        rabbits.Add(newRabbit);
                        rabbit.Age++;
                    }
                    else
                    {
                        rabbit.Age++;
                    }
                }
                #endregion

            }
            #endregion

            #region SumRabbitAge
            int cumulativeRabbitAge = 0;
            rabbits.ForEach(r => cumulativeRabbitAge += r.Age);
            #endregion

            return (cumulativeRabbitAge, rabbits.Count);
        } 
    }

    public class Rabbit
    {
        public int RabbitId {get; set;}
        public string RabbitName { get; set; }
        public int Age { get; set; }

        public Rabbit()
        {

            this.RabbitId = Rabbit_Collection.rabbits.Count + 1;
            RabbitName = "Rabbit" + this.RabbitId;
            Age = 0;
        }
    }
}
