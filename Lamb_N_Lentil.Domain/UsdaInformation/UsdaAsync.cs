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


        public async Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString, string dataSource = "")
        {
            UsdaFood usdaFood = await FetchUsdaFood(searchString, dataSource);
          
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

        public async Task<UsdaFood> FetchUsdaFood(string searchString, string dataSource = "")
        {
               string  _dataSource = "";

            if (dataSource == UsdaDataSource.StandardReference.ToString())
            {
                _dataSource = "Standard Reference";
            }
            else if (dataSource==UsdaDataSource.BrandedFoodProducts.ToString())
            {
                _dataSource = "Branded Food Products";
            }


            HttpClient client = new HttpClient();
            searchString = ReduceStringLengthToWhatWillWorkOnUSDA(searchString);
            string http = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            string apiKey = "&max=5000&offset=0&ds=" + _dataSource + "&api_key=";
            string foodsUrl = String.Concat(http, searchString, apiKey, key);
            client.BaseAddress = new Uri(foodsUrl);

            UsdaFood usdaFood = null;
            FetchedTotalFromSearch = 0;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                var x= await response.Content.ReadAsAsync<UsdaFood>();
                usdaFood = x;
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
        

        public async Task<string> GetManufacturerOrFoodGroup(string ndbno)
        {
            HttpClient client = new HttpClient();

            string http = "https://api.nal.usda.gov/ndb/reports/?ndbno=";
            //                     &type=f&format=json&api_key= 
            string apiKey = "&type=b&format=json&api_key=";
            string foodsUrl = String.Concat(http, ndbno, apiKey, key);

            client.BaseAddress = new Uri(foodsUrl);

            UsdaFoodReport usdaFoodReport = null;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                usdaFoodReport = await response.Content.ReadAsAsync<UsdaFoodReport>();

            }
            string foodGroup = usdaFoodReport.report.food.fg ??"";
            string manufacturer = usdaFoodReport.report.food.manu??"";
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
