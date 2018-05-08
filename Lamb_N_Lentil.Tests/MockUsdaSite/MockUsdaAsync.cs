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
                report.foods[0] = new foods { food = new food() { ing = new ing() { desc = "peas, porridge, hot" } } };
                int setHigherThanEverExpected = 40;
                report.foods[0].food.nutrients = new nutrients[setHigherThanEverExpected];
                report.foods[0].food.nutrients[0] = new nutrients();
                report.foods[0].food.nutrients[0].name = "Energy";
                report.foods[0].food.nutrients[0].nutrient_id = 208; 
                report.foods[0].food.nutrients[0].measures = new measures[1];
                report.foods[0].food.nutrients[0].measures[0] = new measures();
                report.foods[0].food.nutrients[0].measures[0].label = "I am a label";
                report.foods[0].food.nutrients[0].measures[0].eqv = 3.1415926M;
                report.foods[0].food.nutrients[0].measures[0].value = 76M;

                report.foods[0].food.nutrients[1] = new nutrients();
                report.foods[0].food.nutrients[1].name = "Total lipid(fat)";
                report.foods[0].food.nutrients[1].nutrient_id = 204;
                report.foods[0].food.nutrients[1].measures = new measures[1];
                report.foods[0].food.nutrients[1].measures[0] = new measures(); 
                report.foods[0].food.nutrients[1].measures[0].value = 987654.2M ;

                report.foods[0].food.nutrients[2] = new nutrients();
                report.foods[0].food.nutrients[2].nutrient_id = 205;  // total carbs - test w/o label
                report.foods[0].food.nutrients[2].measures = new measures[1];
                report.foods[0].food.nutrients[2].measures[0] = new measures();
                report.foods[0].food.nutrients[2].measures[0].value = 77.04M;

                report.foods[0].food.nutrients[3] = new nutrients();
                report.foods[0].food.nutrients[3].name = "Fatty acids, total saturated";
                report.foods[0].food.nutrients[3].nutrient_id = 606;
                report.foods[0].food.nutrients[3].measures = new measures[1];
                report.foods[0].food.nutrients[3].measures[0] = new measures();
                report.foods[0].food.nutrients[3].measures[0].value = 987654.2M;

                report.foods[0].food.nutrients[4] = new nutrients();
                report.foods[0].food.nutrients[4].name = "Fatty acids, total trans";
                report.foods[0].food.nutrients[4].nutrient_id = 605;
                report.foods[0].food.nutrients[4].measures = new measures[1];
                report.foods[0].food.nutrients[4].measures[0] = new measures();
                report.foods[0].food.nutrients[4].measures[0].value = 101.01M; 


                report.foods[0].food.nutrients[5] = new nutrients();
                report.foods[0].food.nutrients[5].name = "Fatty acids, total polyunsaturated";
                report.foods[0].food.nutrients[5].nutrient_id = 646;
                report.foods[0].food.nutrients[5].measures = new measures[1];
                report.foods[0].food.nutrients[5].measures[0] = new measures();
                report.foods[0].food.nutrients[5].measures[0].value = 736.08M;

                report.foods[0].food.nutrients[6] = new nutrients();
                report.foods[0].food.nutrients[6].name = "Fatty acids, total monounsaturated";
                report.foods[0].food.nutrients[6].nutrient_id = 645;
                report.foods[0].food.nutrients[6].measures = new measures[1];
                report.foods[0].food.nutrients[6].measures[0] = new measures();
                report.foods[0].food.nutrients[6].measures[0].value = 81.92M;

                report.foods[0].food.nutrients[7] = new nutrients();
                report.foods[0].food.nutrients[7].name = "Cholesterol";
                report.foods[0].food.nutrients[7].nutrient_id = 601;
                report.foods[0].food.nutrients[7].measures = new measures[1];
                report.foods[0].food.nutrients[7].measures[0] = new measures();
                report.foods[0].food.nutrients[7].measures[0].value = 82.93M;


                report.foods[0].food.nutrients[8] = new nutrients();
                report.foods[0].food.nutrients[8].name = "Sodium, Na";
                report.foods[0].food.nutrients[8].nutrient_id = 307;
                report.foods[0].food.nutrients[8].measures = new measures[1];
                report.foods[0].food.nutrients[8].measures[0] = new measures();
                report.foods[0].food.nutrients[8].measures[0].value = 143.0M;

                report.foods[0].food.nutrients[9] = new nutrients();
                report.foods[0].food.nutrients[9].measures = new measures[1];
                report.foods[0].food.nutrients[9].measures[0] = new measures();
                report.foods[0].food.nutrients[9].measures[0].value = 1234.56M;

                report.foods[0].food.nutrients[10] = new nutrients();
                report.foods[0].food.nutrients[10].name = "Sugars, total";
                report.foods[0].food.nutrients[10].nutrient_id = 269;
                report.foods[0].food.nutrients[10].measures = new measures[1];
                report.foods[0].food.nutrients[10].measures[0] = new measures();
                report.foods[0].food.nutrients[10].measures[0].value = 14.30M;

                report.foods[0].food.nutrients[11] = new nutrients();
                report.foods[0].food.nutrients[11].name = "Protein";
                report.foods[0].food.nutrients[11].nutrient_id = 203;
                report.foods[0].food.nutrients[11].measures = new measures[1];
                report.foods[0].food.nutrients[11].measures[0] = new measures();
                report.foods[0].food.nutrients[11].measures[0].value = 7.15M;

                report.foods[0].food.nutrients[12] = new nutrients();
                report.foods[0].food.nutrients[12].name = "Vitamin A, IU";
                report.foods[0].food.nutrients[12].nutrient_id = 318;
                report.foods[0].food.nutrients[12].measures = new measures[1];
                report.foods[0].food.nutrients[12].measures[0] = new measures();
                report.foods[0].food.nutrients[12].measures[0].value = 3.625M;

                report.foods[0].food.nutrients[13] = new nutrients();
                report.foods[0].food.nutrients[13].name = "Vitamin C, total ascorbic acid";
                report.foods[0].food.nutrients[13].nutrient_id = 401;
                report.foods[0].food.nutrients[13].measures = new measures[1];
                report.foods[0].food.nutrients[13].measures[0] = new measures();
                report.foods[0].food.nutrients[13].measures[0].value = 1.8M;

                report.foods[0].food.nutrients[14] = new nutrients();
                report.foods[0].food.nutrients[14].name = "Calcium, Ca";
                report.foods[0].food.nutrients[14].nutrient_id = 301;
                report.foods[0].food.nutrients[14].measures = new measures[1];
                report.foods[0].food.nutrients[14].measures[0] = new measures();
                report.foods[0].food.nutrients[14].measures[0].value = 0.95M;

                report.foods[0].food.nutrients[15] = new nutrients();
                report.foods[0].food.nutrients[15].name = "Iron, Fe";
                report.foods[0].food.nutrients[15].nutrient_id = 303;
                report.foods[0].food.nutrients[15].measures = new measures[1];
                report.foods[0].food.nutrients[15].measures[0] = new measures();
                report.foods[0].food.nutrients[15].measures[0].value = 0.114M;

                report.foods[0].food.nutrients[16] = new nutrients();
                report.foods[0].food.nutrients[16].name = "Vitamin D";
                report.foods[0].food.nutrients[16].nutrient_id = 324;
                report.foods[0].food.nutrients[16].measures = new measures[1];
                report.foods[0].food.nutrients[16].measures[0] = new measures();
                report.foods[0].food.nutrients[16].measures[0].value = 0.228M;

                report.foods[0].food.nutrients[17] = new nutrients();
                report.foods[0].food.nutrients[17].name = "Thiamine";
                report.foods[0].food.nutrients[17].nutrient_id = 404;
                report.foods[0].food.nutrients[17].measures = new measures[1];
                report.foods[0].food.nutrients[17].measures[0] = new measures();
                report.foods[0].food.nutrients[17].measures[0].value = 1.228M;

                report.foods[0].food.nutrients[18] = new nutrients();
                report.foods[0].food.nutrients[18].name = "Riboflavin";
                report.foods[0].food.nutrients[18].nutrient_id = 405;
                report.foods[0].food.nutrients[18].measures = new measures[1];
                report.foods[0].food.nutrients[18].measures[0] = new measures();
                report.foods[0].food.nutrients[18].measures[0].value = 3.333M;

                report.foods[0].food.nutrients[19] = new nutrients();
                report.foods[0].food.nutrients[19].name = "Niacin";
                report.foods[0].food.nutrients[19].nutrient_id = 406;
                report.foods[0].food.nutrients[19].measures = new measures[1];
                report.foods[0].food.nutrients[19].measures[0] = new measures();
                report.foods[0].food.nutrients[19].measures[0].value = 21.045M;

                report.foods[0].food.nutrients[20] = new nutrients();
                report.foods[0].food.nutrients[20].name = "VitaminB6";
                report.foods[0].food.nutrients[20].nutrient_id = 415;
                report.foods[0].food.nutrients[20].measures = new measures[1];
                report.foods[0].food.nutrients[20].measures[0] = new measures();
                report.foods[0].food.nutrients[20].measures[0].value = 76.05M;

                report.foods[0].food.nutrients[21] = new nutrients();
                report.foods[0].food.nutrients[21].name = "VitaminB12";
                report.foods[0].food.nutrients[21].nutrient_id = 418;
                report.foods[0].food.nutrients[21].measures = new measures[1];
                report.foods[0].food.nutrients[21].measures[0] = new measures();
                report.foods[0].food.nutrients[21].measures[0].value = 71.055M;


                return report;
            }
            else throw new NotImplementedException("wrong search string");
        }
    }
}
