using System;
using System.Net.Http;
using System.Net.Http.Headers; 
using System.Threading.Tasks;
using static Lamb_N_Lentil.Domain.Foods;
using static Lamb_N_Lentil.Domain.Foods.Food;
using System.Collections.Generic;
using System.Linq;

namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class UsdaAsync : IUsdaAsync
    {
        static string key = "sFtfcrVdSOKA4ip3Z1MlylQmdj5Uw3JoIIWlbeQm";

        public async Task<Foods> GetIngredientFromSearchText(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts)
        {
            try
            {
                string ds = usdaWebApiDataSource == UsdaWebApiDataSource.BrandedFoodProducts ? "" : "ds=Standard+Reference";
                HttpClient client = new HttpClient();
                string http = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                string apiKey = String.Concat("&type=f&format=json&", ds, "&fgcd=", foodGroup, "&api_key=");
                int? ndbno = await GetNdbnoFromSearchStringAsync(client, searchString, ds);
                string foodsUrl = String.Concat(http, ndbno, apiKey, key);
                client.BaseAddress = new Uri(foodsUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string name = "nothing returned";
                string description = "nothing returned";

                HttpResponseMessage response2 = await client.GetAsync(foodsUrl);
                if (response2.IsSuccessStatusCode)
                {
                    UsdaFood food1 = await response2.Content.ReadAsAsync<UsdaFood>();

                    if (ds == "ds=Standard+Reference")
                    {
                        description = food1.foods[0].food.desc.Name;
                    }
                    else
                    {
                        description = food1.foods[0].food.ing != null ? food1.foods[0].food.ing.desc : food1.foods[0].food.footnotes[0].desc;
                        name = food1.foods[0].food.desc.Name;
                    }


                    // do I need to check what happens if ndbno does not have a value??
                    //{
                    //    description = await GetIngredientsByNdbno((int)ndbno, usdaWebApiDataSource);
                    //}
                }
                Desc desc = new Desc() { Name = name };
                Ing ing = new Ing() { desc = description };
                Food food = new Food() { desc = desc, ing = ing };
                Foods entity = new Foods() { food = food };

                return entity;

            }
            catch (Exception ex)
            {
                Desc desc = new Desc() { Name = "error in getting ingredient from web:" + ex.Message };
                Food food = new Food() { desc = desc };
                Foods entity = new Foods() { food = food };
                return entity;
            }
        }


        public async Task<int?> GetNdbnoFromSearchStringAsync(HttpClient client2, string searchString, string dataSource = "")
        {  // TODO: sanitize searchString
           //  "https://api.nal.usda.gov/ndb/search/?format=json&q=aardvark&sort=n&max=1&offset=0&api_key=DEMO_KEY"


            searchString = ReduceStringLengthToWhatWillWorkOnUSDA(searchString);
            int ndbno;
            try
            {
                var food = await GetListOfIngredients(searchString, dataSource);
                ndbno = food.list.item[0].ndbno;
                return ndbno;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return -1;
            }
        }

        public async Task<UsdaFood> GetListOfIngredients(string searchString, string dataSource = "")
        {
            HttpClient client = new HttpClient();
            string http = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            string apiKey = "&max=50&offset=0&" + dataSource + "&api_key=";
            string foodsUrl = String.Concat(http, searchString, apiKey, key);
            client.BaseAddress = new Uri(foodsUrl);

            UsdaFood item = null;
            HttpResponseMessage response = await client.GetAsync(foodsUrl);
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<UsdaFood>();

            }
            return item;
        }

        private static string ReduceStringLengthToWhatWillWorkOnUSDA(string searchString)
        {
            const int MaxStringLengthThatWillWork = 43;
            if (searchString.Length > MaxStringLengthThatWillWork)
            {
                searchString = searchString.Substring(searchString.Length - MaxStringLengthThatWillWork);
            }

            return searchString;
        }


        public async Task<List<IIngredient>> GetListOfIngredientsFromTextSearch(string searchString)
        {
            UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts;
            string foodGroup = "";
            try
            {
                string ds = usdaWebApiDataSource == UsdaWebApiDataSource.BrandedFoodProducts ? "" : "ds=Standard+Reference";
                HttpClient client = new HttpClient();
                string http = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                string apiKey = String.Concat("&type=f&format=json&", ds, "&fgcd=", foodGroup, "&api_key=");


                int? ndbno = await GetNdbnoFromSearchStringAsync(client, searchString, ds);
                string foodsUrl = String.Concat(http, ndbno, apiKey, key);
                client.BaseAddress = new Uri(foodsUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<IIngredient> listOfIngredients = new List<IIngredient>();

                HttpResponseMessage response2 = await client.GetAsync(foodsUrl);
                if (response2.IsSuccessStatusCode)
                {
                    //  UsdaFood food = await response2.Content.ReadAsAsync<UsdaFood>();
                    UsdaFood food = await response2.Content.ReadAsAsync<UsdaFood>();
                    foreach (var individual in food.list.item)
                    {
                        listOfIngredients.Add(new Entity()
                        {
                            InstanceName = individual.name,
                            IngredientsList = individual.ing.desc
                        });
                    } 
                }
               
                return listOfIngredients;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<Entity> GetEntityFromTextSearch(string searchText) => throw new NotImplementedException();

        public Task<string> GetManufacturerOrFoodGroup(int ndbno)
        {
            throw new Exception("not implemented");
        }

        public Task<Entity> GetIngredientFromTextSearch(string searchText)
        {
            throw new Exception("not implemented");
        }

        public async Task<string> GetListOfIngredientPropertyFromTextSearch(string searchString)
        {
            UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts;
            string foodGroup = "";
            try
            {
                string ds = usdaWebApiDataSource == UsdaWebApiDataSource.BrandedFoodProducts ? "" : "ds=Standard+Reference";
                HttpClient client = new HttpClient();
                string http = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                string apiKey = String.Concat("&type=f&format=json&", ds, "&fgcd=", foodGroup, "&api_key=");


                int? ndbno = await GetNdbnoFromSearchStringAsync(client, searchString, ds);
                string foodsUrl = String.Concat(http, ndbno, apiKey, key);
                client.BaseAddress = new Uri(foodsUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string listOfIngredients = "";

                HttpResponseMessage response2 = await client.GetAsync(foodsUrl);
                if (response2.IsSuccessStatusCode)
                {
                    //  UsdaFood food = await response2.Content.ReadAsAsync<UsdaFood>();
                    UsdaFood food = await response2.Content.ReadAsAsync<UsdaFood>();
                    listOfIngredients = food.foods[0].food.ing.desc;

                    //if (ds == "ds=Standard+Reference")
                    //{ 
                    //    list = food.foods;
                    //}
                    //else
                    //{
                    //    list = food.foods;


                    // } 
                }
                //var names= from f in list
                //          select  f.food.desc.Name;
                //  return names.ToList();
                return listOfIngredients;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
