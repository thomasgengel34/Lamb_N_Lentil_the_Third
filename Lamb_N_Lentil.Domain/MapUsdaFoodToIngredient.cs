using System;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Domain
{
    public class MapUsdaFoodToIngredient
    {

        public static async System.Threading.Tasks.Task<IIngredient> ConvertUsdaFoodToIIngredientAsync(UsdaFood food, int index)
        {
            IIngredient ingredient = new Entity();

            ingredient.InstanceName = food.foods[index].food.desc.Name;

            ingredient.IngredientsList = food.foods[index].food.ing.desc; 

            ingredient.Ndbno = food.foods[index].food.desc.Ndbno;

            if (food.list.ds == "BL")
            {
                ingredient.UsdaDataSource = UsdaDataSource.BrandedFoodProducts;
            }
            else
            {
                ingredient.UsdaDataSource = UsdaDataSource.StandardReference;
            } 

            ingredient.Description = ingredient.InstanceName;
            ingredient.ManufacturerOrFoodGroup =await new UsdaAsync().GetManufacturerOrFoodGroup(ingredient.Ndbno);

            return ingredient;
        }

       
    }
}
