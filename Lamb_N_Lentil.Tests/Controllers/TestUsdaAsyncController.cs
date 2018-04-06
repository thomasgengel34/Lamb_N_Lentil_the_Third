using System;
using System.Net.Http;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain.UsdaInformation;
using Lamb_N_Lentil.UI.Controllers;

namespace Lamb_N_Lentil.Tests.Controllers
{
   public class TestUsdaAsyncController : IngredientsController
    {
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



        public Task<int?> GetNdbnoFromSearchStringAsync(HttpClient client2, string searchString, string dataSource = "") => throw new NotImplementedException();



        public async Task<string> GetListOfIngredientsFromTextSearch(string searchString)
        {
           string correctList =   "onion, garlic, turmeric, basil"  ;
            if (searchString != "foo")
            {
                throw new Exception("wrong parameter!");
            }
            else
            {
                await Task.Delay(0);
                return correctList;
            }
        } 
    }
}
