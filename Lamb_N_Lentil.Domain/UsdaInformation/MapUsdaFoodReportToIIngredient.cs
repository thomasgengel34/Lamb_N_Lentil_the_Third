using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class MapUsdaFoodReportToIIngredient
    {
        private static food food;

        public static IIngredient ConvertUsdaFoodReportToIIngredient(food _food)
        {
            IIngredient ingredient = new Entity();
            food = _food;
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
                Convert.ToInt16(food.nutrients[0].measures[0].value);
            }
         
            ingredient.TotalFat = FindNutrient(204); 
            ingredient.TotalCarbohydrate = FindNutrient(205);
            ingredient.Calories = FindNutrient(208);
            ingredient.Sodium =  FindNutrient(307);
            ingredient.Cholesterol = FindNutrient(601);     
            ingredient.SaturatedFat = FindNutrient(606);
            ingredient.PolyunsaturatedFat = FindNutrient(646);
            ingredient.MonounsaturatedFat = FindNutrient(645);
            ingredient.TransFat = FindNutrient(605);
            return ingredient;
        }
         

        private static decimal FindNutrient(int nutrient_ID)
        {
            var target = (from x in food.nutrients
                          where x != null && x.nutrient_id == nutrient_ID && x.measures[0] != null
                          select x.measures[0]).FirstOrDefault();
            if (target==null)
            {
                return 0;
            }
            decimal? result = target.value;
            if (result == null)
            {
                return 0;
            }
            return (decimal)result;
        }
    }
}
