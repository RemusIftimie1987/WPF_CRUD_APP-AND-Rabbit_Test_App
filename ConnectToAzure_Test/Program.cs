using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectToAzure_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = "tcp:remusdatabase.database.windows.net";
            //    builder.UserID = "<remusiftimieadmin>";
            //    builder.Password = "<Octombrie1987>";
            //    builder.InitialCatalog = "<SpartaTrialDatabase>";

            //    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //    {
            //        Console.WriteLine("\nConnection Successful!");
            //        connection.Open();
            //        StringBuilder sb = new StringBuilder();
            //        String sql = sb.ToString();

            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //Console.ReadLine();
        }
    }
}
