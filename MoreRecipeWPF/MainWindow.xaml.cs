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

namespace MoreRecipeWPF
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
                Trace.WriteLine("SQL Connection open..");

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }
        public void CloseConnection()
        {
            this.connection.Close();
            Trace.WriteLine("SQL Connection closed...");
        }
        public DataTable ReadFromSql()
        {
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
    /// 
    public class Ingredient
    {
        public Ingredient getIngredientId ()
        {
            
        }

        public void setIngredientId()
        {

        }

        public Ingredient getIngredientName()
        {

        }

        public void setIngredientName()
        {

        }


        public Boolean getConsumable()
        {

        }


        public Boolean setConsumable()
        {

        }

        public Ingredient getMinimumAmount ()
        {

        }

        public void setMinimumAmount()
        {

        }

        public Ingredient getDailyConsumptionRate()
        {

        }

        public void setDailyConsumptionRate()
        {

        }

        public Ingredient getIngredientCategory()
        {

        }

        public void setIngredientCategory()
        {

        }

        public Ingredient getAmountForRecipe()
        {

        }
        public void setAmountForRecipe()
        {

        }
    }



    public class recipe
    {
        public recipe getRecipeId()
        {

        }
        public void setRecipeId()
        {

        }
        public recipe getRecipeName()
        {

        }
        public void setRecipeName()
        {

        }
        public recipe getRecipeInstructions()
        {

        }
        public void setRecipeInstructions()
        {

        }
        public Boolean checkIngredientFromDatabase()
        {

        }
        public void manualSearchOrAdd()
        {

        }
        public void addToDatabase()
        {

        }
        public void updateAtDatabase()
        {

        }
        public void removeFromDatabaseType()
        {

        }






    }

    public class ingredientInStorage
    {
        public ingredientInStorage getIngredientPrice()
        {

        }
        public void setIngredientPrice()
        {

        }
        public ingredientInStorage getBuyDate()
        {

        }
        public void setBuyDate()
        {

        }
        public ingredientInStorage getExpirationDate()
        {

        }
        public void setExpirationDate()
        {

        }
        public ingredientInStorage getAmountInStorage()
        {

        }
        public void setAmountInStorage()
        {

        }
        public void showIngredientCost()
        {

        }
        public void removeExpired()
        {

        }
        public void checkDatabaseBalance()
        {

        }
        public void addToDatabase()
        {

        }
        public void updateAtDatabase()
        {

        }
        public void removeFromDatabase()
        {

        }
    }




    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newIngredient_Click(object sender, RoutedEventArgs e)
        {
            NewIngredient ingredientWindow = new();
            ingredientWindow.Show();
        }

        private void showHistory_Click(object sender, RoutedEventArgs e)
        {
            History showHistory = new();
            showHistory.Show();
        }

        private void addNewRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void discardNewRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void planRecipe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
