using MySql.Data.MySqlClient;
using MySql.Data;
using System;

namespace ConsoleApp1
{
    public class SqlConnection
    {
        private string connstr, ipaddr, user, database, password;
        private int port;
        MySqlConnection connection;
        public SqlConnection(string ipaddr, string user, string database, string password, int port)
        {
            this.ipaddr = ipaddr;
            this.user = user;
            this.database = database;
            this.password = password;
            this.port = port;
            this.connstr = $"server={this.ipaddr};user={this.user};database={this.database};port={this.port};password={this.password}";
            this.connection = new MySqlConnection(this.connstr);
        }
        public void OpenConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("SQL Connection open..");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CloseConnection()
        {
            this.connection.Close();
            Console.WriteLine("SQL Connection closed...");
        }
        public void ReadFromDatabase(){
            string query = "SELECT * FROM ingredientcategory";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}:\t{rdr[1]} - {rdr[2]}");
            }
            rdr.Close();
        }
        public void UpdateDatabase() { 
        
        }
        public void AddToDatabase() {
            string query = $"INSERT INTO ingredient(IngredientId, IngredientName, IngredientConsumable, IngredientMinimum, IngredientDailyConsumptionRate, RefCategory) VALUES ('', 'kana', 0, 0, 0, 4)";
            
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sql = new SqlConnection("localhost","resepti", "reseptiproj", "1234", 3306);
            sql.OpenConnection();
            sql.AddToDatabase();
            sql.ReadFromDatabase();

            sql.CloseConnection();
            Console.ReadKey();
        }
    }
}
