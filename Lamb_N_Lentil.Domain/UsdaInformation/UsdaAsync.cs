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

        public async Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = "")
        {
            HttpClient client = new HttpClient();
            searchString = ReduceStringLengthToWhatWillWorkOnUSDA(searchString);
            string http = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            string apiKey = "&max=50&offset=0&" + dataSource + "&api_key=";
            string foodsUrl = String.Concat(http, searchString, apiKey, key);
            client.BaseAddress = new Uri(foodsUrl);

            UsdaFood usdaFood = null;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                usdaFood = await response.Content.ReadAsAsync<UsdaFood>();

            }
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


        public async Task<string> GetManufacturerOrFoodGroup(int ndbno)
        {
            HttpClient client = new HttpClient();

            //                  https://api.nal.usda.gov/ndb/reports/?ndbno=   
            string http = "https://api.nal.usda.gov/ndb/reports/?ndbno=";
            //                     &type=f&format=json&api_key= 
            string apiKey = "&type=f&format=json&api_key=";
            string foodsUrl = String.Concat(http, ndbno, apiKey, key);
            client.BaseAddress = new Uri(foodsUrl);

            UsdaFoodReport usdaFoodReport = null;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                usdaFoodReport = await response.Content.ReadAsAsync<UsdaFoodReport>();

            }
            string foodGroup = usdaFoodReport.report.food.fg;
            string manufacturer = usdaFoodReport.report.food.manu;
            string ds = usdaFoodReport.report.food.ds;

            string manufacturerOrFoodGroup = manufacturer;

            if (manufacturer == "")
            {
                manufacturerOrFoodGroup = foodGroup;
            }
            return manufacturerOrFoodGroup;
        }
    }
}
