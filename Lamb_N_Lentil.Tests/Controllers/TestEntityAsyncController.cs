using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;
using Lamb_N_Lentil.UI.Controllers;

namespace Lamb_N_Lentil.Tests.Controllers
{
    class TestEntityAsyncController : IEntityAsyncController
    {
        public async Task<Entity>   GetIngredientFromSearchText(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts)
        {
            Entity entity = new Entity();
            entity.InstanceName = "This is a test";

            entity.IngredientsList = "salt, pepper, butter, garlic, turmeric, egg";
            string description = entity.IngredientsList;
          await Task.Delay(0);
            return   entity;
        }



        public Task<int?> GetNdbnoFromSearchStringAsync(HttpClient client2, string searchString, string dataSource = "") => throw new NotImplementedException();
    }
}
