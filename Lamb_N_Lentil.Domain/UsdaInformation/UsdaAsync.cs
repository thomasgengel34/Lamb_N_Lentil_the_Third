using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class UsdaAsync : IUsdaAsync
    {
        static string key = "sFtfcrVdSOKA4ip3Z1MlylQmdj5Uw3JoIIWlbeQm";
        public int FetchedTotalFromSearch { get; set; }
        public string FetchedIngredientsInIngredient { get; set; }

        public async Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = "")
        {
            UsdaFood usdaFood = await FetchUsdaFood(searchString);

            List<IIngredient> ingredients;
            if (usdaFood.list != null)
            {
                ingredients = await MapUsdaFoodToIngredient.ConvertUsdaFoodToListOfIngredients(usdaFood);
            }
            else
            {
                ingredients = new List<IIngredient>();
            }
            return ingredients;
        }

        public async Task<UsdaFood> FetchUsdaFood(string searchString)
        {
            string _dataSource = "";



            HttpClient client = new HttpClient();
            searchString = ReduceStringLengthToWhatWillWorkOnUSDA(searchString);
            string http = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            string apiKey = "&max=50&offset=0&ds=" + _dataSource + "&api_key=";
            string foodsUrl = String.Concat(http, searchString, apiKey, key);
            client.BaseAddress = new Uri(foodsUrl);

            UsdaFood usdaFood = null;
            FetchedTotalFromSearch = 0;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                usdaFood = await response.Content.ReadAsAsync<UsdaFood>();
            }
            if (usdaFood.list != null)
            {
                FetchedTotalFromSearch = usdaFood.list.total;
            }

            return usdaFood;
        }

        public static string ReduceStringLengthToWhatWillWorkOnUSDA(string searchString = "")
        {
            const int MaxStringLengthThatWillWork = 43;
            searchString = searchString ?? "";
            if (searchString.Length > MaxStringLengthThatWillWork)
            {
                searchString = searchString.Substring(searchString.Length - MaxStringLengthThatWillWork);
            }

            return searchString;
        }


        public async Task<UsdaFoodReport> FetchUsdaFoodReport(string ndbno)
        {
            HttpClient client = new HttpClient();

            string http = "https://api.nal.usda.gov/ndb/V2/reports/?ndbno="; 
            string apiKey = "&type=b&format=json&api_key=";
            string foodsUrl = String.Concat(http, ndbno, apiKey, key);

            client.BaseAddress = new Uri(foodsUrl);

            UsdaFoodReport usdaFoodReport = null;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                usdaFoodReport = await response.Content.ReadAsAsync<UsdaFoodReport>();

            }
            if (usdaFoodReport != null && usdaFoodReport.foods != null && usdaFoodReport.foods.First() != null && usdaFoodReport.foods.First().food != null && usdaFoodReport.foods.First().food.ing != null && usdaFoodReport.foods.First().food.ing.desc != null)
            {
                FetchedIngredientsInIngredient = usdaFoodReport.foods.First().food.ing.desc;
            }
            else
            {
                FetchedIngredientsInIngredient = "Not provided";
            }
            if (usdaFoodReport != null && usdaFoodReport.foods != null && usdaFoodReport.foods.First() != null && usdaFoodReport.foods.First().food != null && usdaFoodReport.foods.First().food.ing == null)
            {
                usdaFoodReport.foods.First().food.ing = new ing() { desc = FetchedIngredientsInIngredient };
            }
            else
            {
                usdaFoodReport.foods.First().food.ing.desc = FetchedIngredientsInIngredient;
            }
            return usdaFoodReport;
        }

        public async Task<UsdaFoodReport> FetchFullUsdaFoodReport(string ndbno)
        {
            HttpClient client = new HttpClient();

            string http = "https://api.nal.usda.gov/ndb/V2/reports/?ndbno="; 
            string apiKey = "&type=f&format=json&api_key=";
            string foodsUrl = String.Concat(http, ndbno, apiKey, key);

            client.BaseAddress = new Uri(foodsUrl);

            UsdaFoodReport usdaFoodReport = null;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                usdaFoodReport = await response.Content.ReadAsAsync<UsdaFoodReport>();

            }
            if (usdaFoodReport != null && usdaFoodReport.foods != null && usdaFoodReport.foods.First() != null && usdaFoodReport.foods.First().food != null && usdaFoodReport.foods.First().food.ing != null && usdaFoodReport.foods.First().food.ing.desc != null)
            {
                FetchedIngredientsInIngredient = usdaFoodReport.foods.First().food.ing.desc;
            }
            else
            {
                FetchedIngredientsInIngredient = "Not provided";
            }
            if (usdaFoodReport.foods.First().food.ing == null)
            {
                usdaFoodReport.foods.First().food.ing = new ing() { desc = FetchedIngredientsInIngredient };
            }
            else
            {
                usdaFoodReport.foods.First().food.ing.desc = FetchedIngredientsInIngredient;
            }
            return usdaFoodReport;
        }
    }
}
