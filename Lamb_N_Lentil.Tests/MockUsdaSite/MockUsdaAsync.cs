using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.Domain.UsdaInformation;

namespace Lamb_N_Lentil.Tests.MockUsdaSite
{
    internal class MockUsdaAsync : IUsdaAsync
    {
        public int FetchedTotalFromSearch { get; set; }
        public string FetchedIngredientsInIngredient { get; set; }

        public async Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string description)
        {
            int someRandomID = 79258888;
            string sampleManufacturerOrFoodGroup;
            if (description == "" || description == UsdaDataSource.Both.ToString())
            {
                sampleManufacturerOrFoodGroup = "Sample Manufacturer Or Food Group For Empty String";
            }
            if (description == UsdaDataSource.BrandedFoodProducts.ToString())
            {
                sampleManufacturerOrFoodGroup = "Sample Manufacturer Or Food Group For Branded Products String";
            }
            if (description == UsdaDataSource.StandardReference.ToString())
            {
                sampleManufacturerOrFoodGroup = "Sample Manufacturer Or Food Group For Standard String";
            }

            await Task.Delay(0);
            List<IIngredient> list = new List<IIngredient>();
            IIngredient ingredient = new Entity() { InstanceName = searchString, ID = someRandomID };

            if (searchString == "This Should Return No Ingredients")
            {
                return list;
            }

            if (searchString == "1000")
                return BuildIngredientList(list, searchString);

            if (searchString == "1003")
                return BuildIngredientList(list, searchString);

            if (searchString == "1049")
                return BuildIngredientList(list, searchString);

            if (searchString == "1050")
                return BuildIngredientList(list, searchString);

            if (searchString == "1051")
                return BuildIngredientList(list, searchString);
            if (searchString == "total")
            {
                FetchedTotalFromSearch = 445321;
                list.Add(ingredient);
                return list;
            }
            else
            {
                list.Add(ingredient);
                return list;
            }
        }

        private static List<IIngredient> BuildIngredientList(List<IIngredient> list, string searchString)
        {
            int length = Convert.ToInt32(searchString) - 1000;
            list.Clear();
            for (int i = 0; i < length; i++)
            {
                list.Add(new Entity { ID = i });
            }
            return list;
        }

        public async Task<string> GetListOfIngredientstFromTextSearch(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts)
        {
            Foods foods = new Foods();
            foods.food = new Foods.Food();
            foods.food.desc = new Foods.Food.Desc();
            foods.food.desc.Name = "This is a test";
            foods.food.ing = new Foods.Food.Ing();
            foods.food.ing.desc = "salt, pepper, butter, garlic, turmeric, egg";
            await Task.Delay(0);
            return foods.food.ing.desc;
        }

        public async Task<string> GetManufacturerOrFoodGroup(string ndbno)
        {
            await Task.Delay(0);
            if (ndbno == "01009")
            {

                return "Valley Brook Farm";
            }
            else
            {
                return "this should not be possible to see";
            }
        }


        public async Task<UsdaFoodReport> FetchUsdaFoodReport(string searchString)
        {
            UsdaFoodReport report = new UsdaFoodReport();
            await Task.Delay(0);
            if (searchString == "ShouldReturnIngredients")
            {
                report.foods = new foods[1];
                food food = new food() { ing = new ing() { desc = "peas, porridge, hot" } };
                foods testfoods = new foods { food = food };
               
                    report.foods[0] = testfoods;  
              
                return report;
            }
            else throw new NotImplementedException();
        }   
    }
}
