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

            ingredient.InstanceName = food.desc.name;
            ingredient.IngredientsInIngredient =food.ing.desc;
            ingredient.UpdateDate = food.ing.upd;
            ingredient.Ndbno = food.desc.ndbno;
            ingredient.Description = food.desc.name; 

            return ingredient;
        }
    }
}
