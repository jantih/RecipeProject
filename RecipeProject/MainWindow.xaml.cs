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
            
            DataTable dt = new();
            dt.Load(cmd.ExecuteReader());
            return dt;
            
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn;
        private DataTable dt;
        public MainWindow()
        {
            this.conn = new("localhost", "resepti", "reseptiproj", "1234", 3306);
            this.dt = new DataTable();
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
            this.dt = this.conn.ReadFromSql();
            dataGrid.DataContext = this.dt;
            // DEBUG -- Iteroidaan SQLstä haetun datan läpi, tätä voi myöhemmin käyttää ingredient listan täyttämiseksi backendin puolella
            foreach (DataRow row in dt.Rows) {
                Trace.WriteLine(row["IngredientName"] + " - " + row["CategoryName"]);
            }
        }

        private void newRecipe_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
