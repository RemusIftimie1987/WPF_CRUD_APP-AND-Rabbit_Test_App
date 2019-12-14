using System;
using Lab_22_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_24_Serialize_Binary
{
    class Program
    {

        static void Main(string[] args)
        {
            var customer = new Customer(1, "Billy", "NR362345");
            var customer2 = new Customer(2, "Mary", "BA662345");
            var customers = new List<Customer>() { customer, customer2 };

            // formatter : allow us to serialize to Binary
            var formatter = new BinaryFormatter();
            //stream to file
            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            }

            //deserialize
            var customersFromJSONBinary = new List<Customer>();
            //stream Read
            using (var reader = File.OpenRead("data.bin"))
            {
                // Deserialize XML => Customer and print
                customersFromJSONBinary = formatter.Deserialize(reader) as List<Customer>;
            }
            customersFromJSONBinary.ForEach(c => Console.WriteLine($"{c.CustomerID}{c.CustomerName}"));

            //Console.WriteLine(customersFromJSONBinary.ForEach(c => Console.WriteLine(customers)));

        }
    }
}
