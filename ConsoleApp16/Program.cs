using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    public class Client
    {
        public int Id { get; set; }
        public string Iin { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("1. Add client");
            Console.WriteLine("2. Show all client");
            Console.WriteLine("3. Search client");
            Console.WriteLine("4. Create account");
            Console.WriteLine("5. Add cash in account");

            Console.Write("select -> ");
            int ch = Convert.ToInt32(Console.ReadLine());

            if (ch == 1)
            {
                Console.Clear();
                Console.WriteLine("-- Add client --");

                Client client = new Client();

                Console.Write("Enter IIN: ");
                client.Iin = Console.ReadLine();

                Console.Write("Enter FullName: ");
                client.FullName = Console.ReadLine();

                Console.Write("Enter Phone: ");
                client.Phone = Console.ReadLine();

                int result = AddClient(client);
                if (result == 1)
                    Console.WriteLine("Cleint add ok!");
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else if (ch == 2)
            {
                List<Client> clients = GetAllClients();
                for (int i = 0; i < clients.Count; i++)
                {
                    Console.WriteLine($"- {clients[i].Iin} {clients[i].FullName} ({clients[i].Phone})");
                }
            }
            else if(ch ==4)
            {

            }

        }

        public static int AddClient(Client client)
        {
            string connectionString = "Server=178.89.186.221, 1434;Database=hotelatr_db;User Id=hotelatr_user_db;Password=A1d8kn&66;TrustServerCertificate=True;";

            SqlConnection coonection = new SqlConnection(connectionString);
            coonection.Open();

            string sql = "INSERT INTO [dbo].[Clients]([Iin],[FullName],[Phone])" +
                         "VALUES(@Iin,@FullName,@Phone)";
            SqlCommand command = new SqlCommand(sql, coonection);

            command.Parameters.AddWithValue("@Iin", client.Iin);
            command.Parameters.AddWithValue("@FullName", client.FullName);
            command.Parameters.AddWithValue("@Phone", client.Phone);

            return command.ExecuteNonQuery();
        }

        public static List<Client> GetAllClients()
        {
            string connectionString = "Server=178.89.186.221, 1434;Database=hotelatr_db;User Id=hotelatr_user_db;Password=A1d8kn&66;TrustServerCertificate=True;";
            SqlConnection coonection = new SqlConnection(connectionString);
            coonection.Open();

            string sql = "SELECT * FROM Clients;";
            SqlCommand command = new SqlCommand(sql, coonection);
            SqlDataReader reader = command.ExecuteReader();

            List<Client> clients = new List<Client>();
            while (reader.Read())
            {
                Client client = new Client();
                client.Iin = reader["Iin"].ToString();
                client.FullName = reader["FullName"].ToString();
                client.Phone = reader["Phone"].ToString();

                clients.Add(client);
            }

            return clients;
        }

        /// <summary>
        /// Метод для получения клиента по его ID
        /// </summary>
        /// <param name="id">ID клеинта</param>
        /// <returns></returns>
        public static Client GetClientById(int id)
        {
            string connectionString = "Server=178.89.186.221, 1434;Database=hotelatr_db;User Id=hotelatr_user_db;Password=A1d8kn&66;TrustServerCertificate=True;";
            SqlConnection coonection = new SqlConnection(connectionString);
            coonection.Open();

            string sql = "SELECT * FROM Clients WHERE Id="+ id;
            SqlCommand command = new SqlCommand(sql, coonection);
            SqlDataReader reader = command.ExecuteReader();

            Client client = new Client();
            while (reader.Read())
            {
                client.Iin = reader["Iin"].ToString();
                client.FullName = reader["FullName"].ToString();
                client.Phone = reader["Phone"].ToString();
            }
            return client;
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

                string sql2 = "INSERT INTO Positions(Name) VALUES(@Name)";
                //coonection

                SqlCommand command2 = new SqlCommand(sql2, coonection);
                command2.Parameters.AddWithValue("@Name", "TEST");
                int rowAffected = command2.ExecuteNonQuery();

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
