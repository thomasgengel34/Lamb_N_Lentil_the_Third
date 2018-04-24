using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class MapUsdaFoodToIngredient
    {
        public static IIngredient ConvertUsdaFoodToIIngredient(Foods[] foods, int index, string ds = "BL")
        {
            IIngredient ingredient = new Entity(); 

            ingredient.InstanceName = foods[index].food.desc.Name; 
            ingredient.IngredientsInIngredient = foods[index].food.ing.desc;
            ingredient.Ndbno = foods[index].food.desc.Ndbno; 

            return ingredient;
        }


        internal static async Task<List<IIngredient>> ConvertUsdaFoodToListOfIngredients(UsdaFood usdaFood)
        {
            List<IIngredient> ingredients = new List<IIngredient>();
            int index = 0;

            foreach (var food in usdaFood.list.item)
            {
                IIngredient ingredient = new Entity();
                ingredient.Description = food.name ?? "";
                ingredient.InstanceName = food.name;
                ingredient.IngredientsInIngredient = await GetIngredientsList(food);
                ingredient.Ndbno = food.ndbno;

                ingredients.Add(ingredient);
                index++; 
            }
            return ingredients;
        }

        private static async Task<string> GetIngredientsList(list.Food food)
        { 
            IUsdaAsync usdaAsync = new UsdaAsync();
            UsdaFoodReport report = await usdaAsync.FetchUsdaFoodReport(food.ndbno);
            string returnedIngredients = report.foods.First().food.ing.desc;
            string alternate="";
            if (food.ing != null)
            {
                alternate= food.ing.desc ?? "Not provided";
            }
            else
            {
                alternate = "Not provided";
            }
            if (returnedIngredients==null||returnedIngredients=="")
            {
                returnedIngredients = alternate;
            }
             return returnedIngredients;
        }
    }
}
