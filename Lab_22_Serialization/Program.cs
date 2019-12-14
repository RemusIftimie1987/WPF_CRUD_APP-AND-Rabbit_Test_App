using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeDeserialize();

            var customer = new Customer(1, "Billy", "NR362345");
            var customer2 = new Customer(2, "Mary", "BA662345");
            var customers = new List<Customer>() { customer, customer2};

            //serisalize the customer to an XML format
            //Create an object for serialization
            //SOAP = Simple object access protocol = XML Transmission mechanism
            var formatter = new SoapFormatter();

            //stream customer to file Write
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //Serialize data to XML as a Stream of data and send to the file stream
                //SEND to the file Stream
                formatter.Serialize(stream, customers);
            }
            //Print out file
            Console.WriteLine(File.ReadAllText("data.xml"));

            // Stream customer to file Write

            //Reverse
            var customersFromXMLFile = new List<Customer>();
            //stream Read
            using (var reader = File.OpenRead("data.xml"))
            {
                // Deserialize XML => Customer and print
                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }
            // and print
            customersFromXMLFile.ForEach(c => Console.WriteLine($"{c.CustomerID}{c.CustomerName}"));
        }

        //TO DO: CONTINUE THIS METHOD
        public static void SerializeDeserialize()
        {
            Product product = new Product
            {
                Name = "Apple",
                ExpiryDate = new DateTime(2019, 12, 05),
                Price = 3.99M,
                Sizes= new string[] { "Small", "Medium", "Large"}
            };

            //serialize
            string output = JsonConvert.SerializeObject(product);
            Console.WriteLine(output);

            //de-serialize
            Product deserializeProduct = JsonConvert.DeserializeObject<Product>(output);
            Console.WriteLine(deserializeProduct.Name);
        }
    }

    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        [NonSerialized]
        private string NINO;   //opt out

        public Customer(int ID, string Name, String Nino)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = Nino;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
