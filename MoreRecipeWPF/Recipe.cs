using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreRecipeWPF
{
   public class Recipe
    {

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }

        public string RecipeInstructions { get; set; }
        public Boolean CheckIngredientFromDataBase { get; }
        public string ManualSearchOrAdd { get; set; }
        public void addToDatabase()
        {

        }
        public void updateAtDatabase()
        {

        }
        public void removeFromDatabaseType()
        {

        }

        public class WPFListBoxModel
        {
            private IList<Recipe> _recipes;
            public IList<Recipe> Recipes
            {
                get
                {
                    if (_recipes == null)
                        _recipes = new List<Recipe>();
                    return _recipes;
                }
                set { _recipes = value; }
            }
        }

    }
}
