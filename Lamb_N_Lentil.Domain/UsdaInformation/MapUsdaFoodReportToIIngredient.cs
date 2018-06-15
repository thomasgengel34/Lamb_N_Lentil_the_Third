using System;
using System.Linq;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class MapUsdaFoodReportToIIngredient
    {
        private static food food;

        public static IIngredient ConvertUsdaFoodReportToIIngredient(UsdaFoodReport _report)
        {
            IIngredient ingredient = new Entity();
            food = _report.foods[0].food;
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
                ingredient.ManufacturerOrFoodGroup = GetManufacturerOrFoodGroup(food);
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

            ingredient.TotalFat = FindNutrientValue(204);
            ingredient.TotalCarbohydrate = FindNutrientValue(205);
            ingredient.Calcium = FindNutrientValue(301);
            ingredient.Calories = FindNutrientValue(208);
            ingredient.DietaryFiber = FindNutrientValue(291);
            ingredient.FolicAcid = FindNutrientValue(431);
            ingredient.Iron = FindNutrientValue(303);
            ingredient.Magnesium = FindNutrientValue(304);
            ingredient.Niacin = FindNutrientValue(406);
            ingredient.Potassium = FindNutrientValue(306);
            ingredient.Sodium = FindNutrientValue(307);
            ingredient.Cholesterol = FindNutrientValue(601);
            ingredient.SaturatedFat = FindNutrientValue(606);
            ingredient.PolyunsaturatedFat = FindNutrientValue(646);
            ingredient.MonounsaturatedFat = FindNutrientValue(645);
            ingredient.TransFat = FindNutrientValue(605);
            ingredient.Sugars = FindNutrientValue(269);
            ingredient.Protein = FindNutrientValue(203);
            ingredient.VitaminA = FindNutrientValue(318);
            ingredient.VitaminB6 = FindNutrientValue(415);
            ingredient.VitaminB12 = FindNutrientValue(418);
            ingredient.VitaminC = FindNutrientValue(401);
            ingredient.VitaminD = FindNutrientValue(324);
            ingredient.Thiamine = FindNutrientValue(404);
            ingredient.Riboflavin = FindNutrientValue(405);

            ingredient.TotalFatUnit = FindNutrientUnit(204);
            //ingredient.TotalCarbohydrateUnit = FindNutrientUnit(205);
            //ingredient.CalciumUnit = FindNutrientUnit(301);
            //ingredient.CaloriesUnit = FindNutrientUnit(208);
            //ingredient.DietaryFiberUnit = FindNutrientUnit(291);
            //ingredient.FolicAcidUnit = FindNutrientUnit(431);
            //ingredient.IronUnit = FindNutrientUnit(303);
            //ingredient.MagnesiumUnit = FindNutrientUnit(304);
            //ingredient.NiacinUnit = FindNutrientUnit(406);
            //ingredient.PotassiumUnit = FindNutrientUnit(306);
             ingredient.SodiumUnit = FindNutrientUnit(307);
            ingredient.CholesterolUnit = FindNutrientUnit(601);
            ingredient.SaturatedFatUnit = FindNutrientUnit(606);
            ingredient.PolyunsaturatedFatUnit = FindNutrientUnit(646);
             ingredient.MonounsaturatedFatUnit = FindNutrientUnit(645);
             ingredient.TransFatUnit = FindNutrientUnit(605);
            //ingredient.Sugars = FindNutrientUnit(269);
            //ingredient.Protein = FindNutrientUnit(203);
            //ingredient.VitaminA = FindNutrientUnit(318);
            //ingredient.VitaminB6 = FindNutrientUnit(415);
            //ingredient.VitaminB12 = FindNutrientUnit(418);
            //ingredient.VitaminC = FindNutrientUnit(401);
            //ingredient.VitaminD = FindNutrientUnit(324);
            //ingredient.Thiamine = FindNutrientUnit(404);
            //ingredient.Riboflavin = FindNutrientUnit(405);

            return ingredient;
        }

        private static string GetManufacturerOrFoodGroup(food food)
        {
            if (food.desc.fg == null || food.desc.fg == "")
            {
                if (food.desc.manu == null || food.desc.manu == "")
                {
                    return "not provided";
                }
                else return food.desc.manu; 
            }
            return food.desc.fg;
        }

        private static decimal FindNutrientValue(int nutrient_ID)
        {
            if (food.nutrients == null) return 0;

            var target = (from x in food.nutrients
                          where x != null && x.nutrient_id == nutrient_ID && x.measures[0] != null
                          select x.measures[0]).FirstOrDefault();
            if (target == null)
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

        private static string FindNutrientUnit(int nutrient_ID)
        {
            if (food.nutrients == null) return "";

            var target = (from x in food.nutrients
                          where x != null && x.nutrient_id == nutrient_ID  
                          select x.unit).FirstOrDefault();
            if (target == null)
            {
                return "";
            }
            string result = target ;
            if (result == null)
            {
                return "";
            }
            return result;
        }
    }
}
