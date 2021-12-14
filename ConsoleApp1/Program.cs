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
                //Console.WriteLine("SQL Connection open..");

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
        public void ReadFromDatabase() {
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
        public void testi()
        {
            Console.Clear();
            Console.WriteLine("1 Add a recipe");
            Console.WriteLine("2 Show recipes you want to prepare");
            Console.WriteLine("3 Show food in storage");
            Console.WriteLine(" ");
            Console.WriteLine("Choose the number to proceed, or press 0 to exit");
            int vastaus = Convert.ToInt32(Console.ReadLine());

            if (vastaus == 1) {
                Console.WriteLine("valinta 1");
                addRecipe();
            }
            else if (vastaus == 2)
            {
                Console.Clear();
                showRecipe();
                planMeal();
            }
            else if (vastaus == 3)
            {
                Console.Clear();
                showStorage();
            }
            else if (vastaus == 0)
            {
                Environment.Exit(0);
            }
        }

        public void planMeal() {
            Console.WriteLine("Choose your recipe by ID, or exit to menu by pressing 0");
            int vastaus = Convert.ToInt32(Console.ReadLine());
            if (vastaus == 0)
            {
                testi();
            }
            //Store chosen recipe name
            string query = "SELECT RecipeName, recipeinstructions FROM recipe WHERE RecipeId = " + vastaus + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                Console.Clear();
                Console.WriteLine($"{rdr[0]} \r\n \r\n {rdr[1]}");
            }
            string chosenRecipe = rdr[0].ToString();
            rdr.Close();
            
            //Print ingredients of chosen recipe
            string query1 = "select ingredientname, recipeingredientsamount, units from recipeingredientamount where recipename = '" + chosenRecipe +"';";
            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            Console.WriteLine(" \r\n Ingredients \r\n");
            
            while (rdr1.Read())
            {
                Console.WriteLine($"{rdr1[0]} {rdr1[1]} {rdr1[2]}\r\n ");

            }

            rdr1.Close();

            Console.WriteLine("Press n to exit back to the menu");
            string vas = Console.ReadLine();
            if (vas == "n")
            {
                testi();
            }


            //Construction of shopping list????????????????????????????
        }
        public void makeMeal()
        {
            //Store food in storage & recipe ingredients
            //Compare both tables
            //
        }
        public void showRecipe()
        {
            string query = "SELECT RecipeId, RecipeName FROM recipe;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]} - {rdr[1]}");
            }
            rdr.Close();
        }
        public void showStorage()
        {
            string query = "SELECT * FROM `foodinstorage_view` ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]} - {rdr[1]}");
            }
            rdr.Close();
            Console.WriteLine("Press n to exit back to the menu");
            string vas = Console.ReadLine();
            if (vas == "n")
            {
                testi();
            }
        }
        public void addRecipe()
        {
            Console.Clear();
            Console.WriteLine("Please write recipe name, or exit to menu by pressing n");
            string reseptiNimi = Console.ReadLine();
            if (reseptiNimi == "n")
            {
                testi();
            }

            Console.WriteLine("Please write recipe instructions");
            string reseptiOhjeet = Console.ReadLine();

            //Insert recipe name and intructions into database;
            string query = "INSERT INTO recipe (RecipeId, RecipeName, RecipeInstructions) VALUES('','" + reseptiNimi + "', '" + reseptiOhjeet + "')";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

            //Print all ingredients, if you need to add one press 1
            Console.Clear();
            showIngredient();

            Console.WriteLine("if you need to add new ingredient press 1 or press 2 to proceed");
            int vastaus_aines = Convert.ToInt32(Console.ReadLine());

            if (vastaus_aines == 1)
            {
                addIngredient();
            }
            else if (vastaus_aines == 2)
            {
                intoRecipe();
            }



        }
        public void showIngredient()
        {
            string query = "SELECT ingredientID, ingredientName FROM ingredient;";
            MySqlCommand aines = new MySqlCommand(query, connection);
            MySqlDataReader ainekset = aines.ExecuteReader();
            while (ainekset.Read())
            {
                Console.WriteLine($"{ainekset[0]} - {ainekset[1]}");
            }
            ainekset.Close();
        }
        public void addIngredient()
        {
            string ainesNimi = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Please write ingredient name. If you dont need any more ingredient Write no");
                ainesNimi = Console.ReadLine();
                if (ainesNimi == "no")
                {
                    intoRecipe();
                }

                Console.WriteLine("Please write price");
                int ainesHinta = Convert.ToInt32(Console.ReadLine());


                //Insert new ingredients into ingredient table
                string lisaa_aines = "INSERT INTO ingredient (IngredientId, IngredientName,Price) VALUES('','" + ainesNimi + "', '" + ainesHinta + "')";
                MySqlCommand komento = new MySqlCommand(lisaa_aines, connection);
                MySqlDataReader lukija = komento.ExecuteReader();
                lukija.Close();
            } while (ainesNimi != null);

        }

        public void intoRecipe()
        {
            Console.Clear();
            showRecipe();
            Console.WriteLine("Choose your recipe by ID number");
            int reseptiID = Convert.ToInt32(Console.ReadLine());

            int aines;
            do
            {
                Console.Clear();
                showIngredient();
                Console.WriteLine("Choose ingredients for your recipe by their ID, if there is no more ingredients press 0");
                aines = Convert.ToInt32(Console.ReadLine());
                if (aines == 0)
                {
                    testi();
                }
                
                string query = "SELECT ingredientId FROM ingredient WHERE ingredientID = " + aines + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                Console.WriteLine("Choose ingredients amount");
                int ainesMaara = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose unit");
                string ainesYksikko = Console.ReadLine();

                string lause = "INSERT INTO recipeingredients (Id, IngredientId, RecipeId, RecipeIngredientsAmount, units) VALUES ('','" + aines + "','"+reseptiID+"','" + ainesMaara + "','" + ainesYksikko + "')";
                MySqlCommand cmd1 = new MySqlCommand(lause, connection);
                MySqlDataReader rdr1 = cmd1.ExecuteReader();
                rdr1.Close();

            } while (aines != 0);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sql = new SqlConnection("localhost","root", "reseptiprojektireal", "", 3306);
            sql.OpenConnection();
            //sql.AddToDatabase();
            //sql.ReadFromDatabase();
            sql.testi();

            //sql.CloseConnection();
            Console.ReadKey();
        }
    }
}
