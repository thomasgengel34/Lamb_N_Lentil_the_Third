using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;

namespace Lamb_N_Lentil.UI.Controllers
{
    public class EntityAsyncController : IEntityAsyncController
    { 
        static string key = "sFtfcrVdSOKA4ip3Z1MlylQmdj5Uw3JoIIWlbeQm";

        public async Task<Entity> GetIngredientFromSearchText(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts)
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
                    UsdaFood food = await response2.Content.ReadAsAsync<UsdaFood>();

                    if (ds == "ds=Standard+Reference")
                    {
                        description = food.foods[0].food.desc.Name;
                    }
                    else
                    {
                        description = food.foods[0].food.ing != null ? food.foods[0].food.ing.desc : food.foods[0].food.footnotes[0].desc;
                        name = food.foods[0].food.desc.Name;
                    }

                     
                    // do I need to check what happens if ndbno does not have a value??
                    //{
                    //    description = await GetIngredientsByNdbno((int)ndbno, usdaWebApiDataSource);
                    //}
                }
                Entity entity = new Entity() { InstanceName = name, IngredientsList = description };
                 return entity;

            }
            catch (Exception ex)
            { 
                Entity entity = new Entity() { InstanceName = "error in getting ingredient from web:" + ex.Message  };
                return entity; 
            }
        }


        public async Task<int?> GetNdbnoFromSearchStringAsync(HttpClient client2,string searchString, string dataSource = "")
        {  // TODO: sanitize searchString
           //  "https://api.nal.usda.gov/ndb/search/?format=json&q=aardvark&sort=n&max=1&offset=0&api_key=DEMO_KEY"


            searchString = ReduceStringLengthToWhatWillWorkOnUSDA(searchString);
            try
            {
                HttpClient client = new HttpClient();
                string http = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
                string apiKey = "&max=1&offset=0&" + dataSource + "&api_key=";
                string foodsUrl = String.Concat(http, searchString, apiKey, key);
                client.BaseAddress = new Uri(foodsUrl);

                int? ndbno = null;
                HttpResponseMessage response = await client.GetAsync(foodsUrl);
                if (response.IsSuccessStatusCode)
                {
                    UsdaSingleItemSearch item = await response.Content.ReadAsAsync<UsdaSingleItemSearch>();
                    ndbno = item.list.item[0].ndbno;
                }
                return ndbno;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return -1;
            }
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
    }
}
