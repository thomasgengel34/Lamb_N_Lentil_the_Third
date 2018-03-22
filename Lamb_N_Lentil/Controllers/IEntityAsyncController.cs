using System.Net.Http;
using System.Threading.Tasks;
using Lamb_N_Lentil.Domain;

namespace Lamb_N_Lentil.UI.Controllers
{
    public interface IEntityAsyncController
    {
        Task<Entity> GetIngredientFromSearchText(string searchString, string foodGroup = "", UsdaWebApiDataSource usdaWebApiDataSource = UsdaWebApiDataSource.BrandedFoodProducts);

        Task<int?> GetNdbnoFromSearchStringAsync(HttpClient client2, string searchString, string dataSource = "");
    }
}