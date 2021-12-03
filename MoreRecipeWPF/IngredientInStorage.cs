using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreRecipeWPF
{
   public class IngredientInStorage
    {
        public int IngredientPrice { get; set; }
        public int BuyDate { get; set; }

        public int ExpirationDate { get; set; }
        public int AmountInStorage { get; set; }
        public string ManualSearchOrAdd { get; set; }

        public int showIngredientCost { get; }
        
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
}
