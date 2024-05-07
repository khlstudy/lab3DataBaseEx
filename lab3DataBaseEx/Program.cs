using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3DataBaseEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection...");

                conn.Open();

                Console.WriteLine("Connection successful!");
                QueryEmploye(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.ReadLine();
        }

        private static void QueryEmploye(MySqlConnection conn)
        {
            string id, name, countryCode;
            string sql = "SELECT Id, Name, CountryCode FROM city";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["Id"].ToString();
                        name = reader["Name"].ToString();
                        countryCode = reader["CountryCode"].ToString();
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Код: " + id+"Назва: " + name+"Код країни: " + countryCode);
                        Console.WriteLine("-----------------------------------------");
                    }
                }
            }
        }
    }
}
