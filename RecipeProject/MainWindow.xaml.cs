using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace RecipeProject
{
    /// <summary>
    /// Connection to MySQL Server
    /// Provide serverinfo for the constructor
    /// </summary>
    public class SqlConnection {
        private string connstr, ipaddr, user, database, password;
        private int port;
        MySqlConnection connection;
        public SqlConnection(string ipaddr, string user, string database, string password, int port) {
            this.ipaddr = ipaddr;
            this.user = user;
            this.database = database;
            this.password = password;
            this.port = port;
            this.connstr = $"server={this.ipaddr};user={this.user};database={this.database};port={this.port};password={this.password}";
            this.connection = new MySqlConnection(this.connstr);
        }
        public void OpenConnection() {
            try
            {
                this.connection.Open();
                Trace.WriteLine("SQL Connection open..");
                
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }
        public void CloseConnection() {
            this.connection.Close();
            Trace.WriteLine("SQL Connection closed...");
        }
        public DataTable ReadFromSql() {
            string query = "SELECT * FROM ingredientcategory";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            /*MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Trace.WriteLine($"{rdr[0]}:\t{rdr[1]} - {rdr[2]}");
            }
            rdr.Close();*/
            DataTable dt = new();
            dt.Load(cmd.ExecuteReader());
            return dt;
            /*
                string sql = "INSERT INTO test(name, country, job) VALUES ('Jose', 'Mexico','Unemployed')";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            */
            
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
        public MainWindow()
        {
            this.conn = new("localhost", "resepti", "reseptiproj", "1234", 3306);
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            this.conn.OpenConnection();
        }

        private void Disconnect_Button_Click(object sender, RoutedEventArgs e)
        {
            this.conn.CloseConnection();
        }

        private void readSql_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.DataContext = this.conn.ReadFromSql();
        }
    }
}
