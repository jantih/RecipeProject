using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreRecipeWPF
{
    public class Ingredient
    {
		public int IngredientId { get; set; }
		public string IngredientName { get; set; }
		public Boolean Consumable { get; set; }
		public int MinimumAmount { get; set; }
		public int DailyConsumptionRate { get; set; }
		public string IngredientCategory { get; set; }

		public int AmmountForRecipe { get; set; }


	}
}
