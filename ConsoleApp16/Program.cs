using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=178.89.186.221, 1434;Database=hotelatr_db;User Id=hotelatr_user_db;Password=A1d8kn&66;TrustServerCertificate=True;";
            SqlConnection coonection = new SqlConnection(connectionString);

            try
            {
                coonection.Open();
                Console.WriteLine("Connection open!");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting: " +
                    ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred: " +
                   ex.Message);
            }
        }
    }
}
