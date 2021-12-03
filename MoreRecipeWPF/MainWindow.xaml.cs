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
            string query = "SELECT * FROM recipe";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            DataTable dt = new();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        public DataTable ShowRecipes()
        {
            string query = "SELECT * FROM recipe";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            DataTable dt1 = new();
            dt1.Load(cmd.ExecuteReader());
            return dt1;
        }





        




        
    }

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        /// 










        /*public class category
        {
            public void showIngredients()
            {

            }
            public void showIngredientCost()
            {

            }
            public void addToCategory()
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
        }*/


        public partial class MainWindow : Window
        {

            private MySqlConnection conn;
            private DataTable dt;
        private MySqlDataAdapter dataAdapter;
        private DataSet ds;
        private string connstructor;
        public MainWindow()
            {
                
            }


        public void fill_IngredientsListBox()
        {

            try
            {
                MySqlConnection connection = new MySqlConnection(this.connstructor);
                connection.Open();
                string query = "SELECT * FROM ingredient";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                dataAdapter = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dataAdapter.Fill(ds, "ingredient");
                Ingredient ing = new Ingredient();
                IList<Ingredient> ing1 = new List<Ingredient>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ing1.Add(new Ingredient
                    {
                        IngredientId = Convert.ToInt32(dr[0].ToString()),
                        IngredientName = dr[1].ToString(),

                    });
                }
                ingredientListBox.ItemsSource = ing1;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ds = null;
                dataAdapter.Dispose();
                conn.Close();
                conn.Dispose();
            }


        }


        public void fill_RecipesListBox()
        {


            /*MySqlConnection connection = new MySqlConnection(this.connstr);
            string query = "SELECT * FROM recipe";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader dbr;
            
            

               this.connection.Open();

                dbr = cmd.ExecuteReader();

                while (dbr.Read())

                {

                (new Recipe { RecipeId = dbr.GetInt32(0), RecipeName = dbr.GetString(1) });

                

                }

            
            */

            try
            {
                MySqlConnection connection = new MySqlConnection(this.connstructor);
                connection.Open();
                string query = "SELECT * FROM recipe";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                dataAdapter = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dataAdapter.Fill(ds, "recipe");
                Recipe re = new Recipe();
                IList<Recipe> re1 = new List<Recipe>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    re1.Add(new Recipe
                    {
                        RecipeId = Convert.ToInt32(dr[0].ToString()),
                        RecipeName = dr[1].ToString(),

                    });
                }
                allRecipes.ItemsSource = re1;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ds = null;
                dataAdapter.Dispose();
                conn.Close();
                conn.Dispose();
            }





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
        private void showRecipes_Click(object sender, RoutedEventArgs e)
        {

        }



        

        private void allRecipes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var recipe = (Recipe)item.SelectedItem;
            MessageBox.Show("(ID: " + recipe.RecipeId + recipe.RecipeName + ")");
        }

        private void ingredientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var ingredient = (Ingredient)item.SelectedItem;
            MessageBox.Show( "(ID: " + ingredient.IngredientId  + ingredient.IngredientName + ")");
        }
    }
    }

