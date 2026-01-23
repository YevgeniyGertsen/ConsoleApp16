using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

            SqlCon();
        }

        public static void OleDbCon()
        {
            string connectionStrins = "Provider=MSOLEDBSQL;Server=178.89.186.221,1434;Database=hotelatr_db;UID=hotelatr_user_db;PWD=A1d8kn&66;";
            using (OleDbConnection connection = new OleDbConnection(connectionStrins))
            {
                connection.Open();
                Console.WriteLine("Connection open!");
            }
        }

        //public void OdbcCon()
        //{
        //    using (Odbc)
        //    {

        //    }
        //}

        public static void SqlCon()
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

                string sql = "SELECT * FROM Positions";
                SqlCommand command = new SqlCommand(sql, coonection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();

                    Console.WriteLine($"{id} - {name}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting: " +
                    ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " +
                   ex.Message);
            }
        }
    }
}
