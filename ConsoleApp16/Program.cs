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

                Console.WriteLine("ConnectionString: {0}", coonection.ConnectionString);
                Console.WriteLine("Database: {0}", coonection.Database);
                Console.WriteLine("ServerVersion: {0}", coonection.ServerVersion);
                Console.WriteLine("State: {0}", coonection.State);
                Console.WriteLine("WorkstationId: {0}", coonection.WorkstationId);
                Console.WriteLine("DataSource: {0}", coonection.DataSource);
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
