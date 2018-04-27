using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class MapUsdaFoodReportToIIngredient
    {
        public static IIngredient ConvertUsdaFoodReportToIIngredient(food food)
        {
            IIngredient ingredient = new Entity();
            if (food == null)
            {
                return ingredient;
            }
            if (food.desc != null)
            {
                ingredient.InstanceName = food.desc.name;
                ingredient.IngredientsInIngredient = food.ing.desc;
                ingredient.Ndbno = food.desc.ndbno;
                ingredient.Description = food.desc.name;
            }
            if (food.ing != null)
            {
                ingredient.UpdateDate = food.ing.upd;
            }

            if (food.nutrients != null && food.nutrients != null && food.nutrients.First() != null)
            {
                ingredient.Label = food.nutrients.First().measures.First().label;
                ingredient.Eqv = food.nutrients.First().measures.First().eqv;
                ingredient.Calories = Convert.ToInt16( food.nutrients[0].measures[0].value);
            }  
            return ingredient;
        }
    }
}
