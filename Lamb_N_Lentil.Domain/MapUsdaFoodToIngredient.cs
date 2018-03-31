using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{


    public class MapUsdaFoodToIngredient : IMapUsdaFoodToIngredient
    {
        public static async Task<IIngredient> ConvertUsdaFoodToIIngredientAsync(Foods[] foods, int index, string ds = "BL")
        {
            IIngredient ingredient = new Entity();

            ingredient.InstanceName = foods[index].food.desc.Name;

            ingredient.IngredientsList = foods[index].food.ing.desc;

            ingredient.Ndbno = foods[index].food.desc.Ndbno;

            if (ds == "BL")
            {
                ingredient.UsdaDataSource = UsdaDataSource.BrandedFoodProducts;
            }
            else
            {
                ingredient.UsdaDataSource = UsdaDataSource.StandardReference;
            }

            ingredient.Description = ingredient.InstanceName;
            ingredient.ManufacturerOrFoodGroup = await new MapUsdaFoodToIngredient().GetManufacturerOrFoodGroup(ingredient.Ndbno);

            return ingredient;
        }

        public async Task<string> GetManufacturerOrFoodGroup(int ndbno) => await new UsdaAsync().GetManufacturerOrFoodGroup(ndbno);

        internal static async Task<List<IIngredient>> ConvertUsdaFoodToListOfIngredients(UsdaFood usdaFood)
        {
            List<IIngredient> ingredients = new List<IIngredient>();
            int index = 0;

            foreach (var food in usdaFood.list.item)
            {
                if (food.ds == "BL")
                {
                    IIngredient ingredient = new Entity();
                    ingredient.Ndbno = food.ndbno;
                    ingredient.UsdaDataSource = (food.ds == "sr") ? UsdaDataSource.StandardReference : UsdaDataSource.BrandedFoodProducts;
                    ingredient.InstanceName = food.name;
                    ingredient.Description = food.name;
                    ingredient.ManufacturerOrFoodGroup = await new MapUsdaFoodToIngredient().GetManufacturerOrFoodGroup(ingredient.Ndbno);

                    ingredients.Add(ingredient);
                    index++;
                }
            }
            return ingredients;
        }
    }
}
